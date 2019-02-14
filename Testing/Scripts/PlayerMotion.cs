using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    Animator anim;
    public float speed = 6.0f;
    //public float rotateSpeed = 6.0f;
    private bool gamestart = false;

    //private Vector3 moveDirection = Vector3.zero;
    //private CharacterController controller;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    public void BeginGame()
    {
       gamestart = true;
    }

    void Update()
    {
        if (gamestart == true)
        {
            //CharacterController controller = GetComponent<CharacterController>();
            // Rotate around y - axis
            //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
            // Move forward / backward
            //Vector3 forward = transform.TransformDirection(Vector3.forward);
            //float curSpeed = speed * Input.GetAxis("Vertical");
            //controller.SimpleMove(forward * curSpeed);

            ControlPlayer();
        }
    }

    void RunAnimation()
    {
        anim.SetFloat("MoveSpeed",1.0f);
    }


    void ControlPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            RunAnimation();
        }
        else{
            anim.SetFloat("MoveSpeed", 0.0f);
        }


        transform.Translate(movement * speed * Time.deltaTime, Space.World);


        //if (Input.GetButtonDown("Fire1"))
        //{
         //   animation.Play("attack-01");
        //}
    }
}
