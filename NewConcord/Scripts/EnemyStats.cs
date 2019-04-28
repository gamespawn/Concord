using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //Animator anim;
    public Transform healthBar;
    public float maxHealth = 1.0f;
    public float currHealth = 1.0f;
    public float power = 10.0f;
    private float playerPower = 1.0f;
    public bool dead = false;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        playerPower = player.GetComponent<PlayerStats>().attack;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "SwordHitbox")
        {
            Debug.Log("HIT");
            currHealth = currHealth - playerPower;
            if(currHealth > -1)
            {
                healthBar.localScale = new Vector3(currHealth / maxHealth , 1.0f);
            }
            Debug.Log(playerPower);
            //Debug.Log(currHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth <= 0.0f)
        {
            //anim.SetBool("Slime_Alive",false);
            dead = true;
        }
    }
}
