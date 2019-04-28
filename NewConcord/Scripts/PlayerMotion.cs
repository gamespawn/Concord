using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    Animator anim;
    public float speed = 6.0f;
    private float trackSpeed = 1.0f;
    public float rollDistance = 1.0f;
    //public float rotateSpeed = 6.0f;
    private bool gamestart = false;
    public bool midAttack = false;
    public bool continueAttack = false;
    //public bool swordGrip = false;
    public bool deadTest = false;
    public bool invulnerable = false;
    public bool isRolling = false;
    public GameObject gamemanager;
    public Camera cam;
    public GameObject player;
    public GameObject sword;
    public GameObject swordLight;
    public GameObject swordHitbox;
    public GameObject swordGrabRange;
    public GameObject hand;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void beginRoll()
    {
        invulnerable = true;
        isRolling = true;
        //transform.Translate(Vector3.forward * 10 * Time.deltaTime);
    }

    public void endRoll()
    {
        invulnerable = false;
        isRolling = false;
        anim.SetBool("roll", false);
        //ALLOW FOR ATTACKING IMMEDIATELY AFTERWARDS
    }

    public void swordStrike()
    {
        swordHitbox.SetActive(true);
    }

    public void endStrike()
    {
        swordHitbox.SetActive(false);
    }

    void attackBegin()
    {
        midAttack = true;
        trackSpeed = speed;
        speed = 1.0f;
        continueAttack = false;
        anim.SetBool("continueCombo",false);
    }

    void attackEnd()
    {
        speed = trackSpeed;
        if(continueAttack == true)
        {
            anim.SetBool("continueCombo",true);
        }
        midAttack = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hitbox")
        {
            Debug.Log("JELLO");
            this.GetComponent<Rigidbody>().AddForce(transform.forward * -2.0f);
        }
    }

    //void OnTriggerStay(Collider other)
    //{
    //    //Debug.Log("YO");
    //    if(other.gameObject.name == "SwordGrab")
    //    {
    //        //Debug.Log("HEY");
    //        if(Input.GetKeyDown("space"))
    //        {
    //            swordLight.SetActive(false);
    //            swordGrabRange.SetActive(false);
    //            sword.transform.SetParent(hand.transform);
    //            sword.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
    //            sword.transform.Rotate(0.0f, 90.0f, -45.0f);
    //            anim.SetBool("SwordHeld",true);
    //            swordGrip = true;
    //        }
    //    }
    //}

    void Update()
    {
        deadTest = player.GetComponent<PlayerStats>().playerDead;
        gamestart = gamemanager.GetComponent<gamemanager>().gameStart;
        if(deadTest == true)
        {
            anim.SetBool("isDead",true);
        }
        else if (gamestart == true)
        {
            if(isRolling == true)
            {
                transform.Translate(Vector3.forward * rollDistance * Time.deltaTime);
            }
            else
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Attack();
                }
                else if(Input.GetMouseButtonDown(1))
                {
                    anim.SetBool("roll", true);
                }
                else
                {
                    //anim.SetBool("punchAttack1", false);
                    anim.SetBool("swordAttack1", false);
                    ControlPlayer();
                }

                if(midAttack == true)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        continueAttack = true;
                    }
                }
            }
        }
    }

    void Attack()
    {
        //if(swordGrip == true)
        //{
            anim.SetBool("swordAttack1", true);
        //}
        //else{
        //    anim.SetBool("punchAttack1", true);
        //}
    }

    void ControlPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            anim.SetFloat("MoveSpeed",1.0f);
        }
        else{
            anim.SetFloat("MoveSpeed", 0.0f);
        }


        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
