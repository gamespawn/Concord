using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    //Animator anim;
    public float maxHealth = 1.0f;
    public float currHealth = 1.0f;
    public float attack = 1.0f;
    private float slimePower = 1.0f;

    public bool playerDead = false;
    public GameObject slime;
    public GameObject player;
    public Transform healthBar;
    // Start is called before the first frame update
    void Start()
    {
        slimePower = slime.GetComponent<EnemyStats>().power;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hitbox")
        {
            if(player.GetComponent<PlayerMotion>().invulnerable == false)
            {
                Debug.Log("HIT");
                currHealth = currHealth - slimePower;
                if(currHealth > -1)
                {
                    healthBar.localScale = new Vector3(currHealth / maxHealth , 1.0f);
                }
                Debug.Log(slimePower);
                Debug.Log(currHealth);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth <= 0.0f)
        {
            playerDead = true;
        }
    }
}
