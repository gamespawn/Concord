using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inRange = false;
    public bool deadCheck = false;
    public float range = 5;
    public float attackRange = 2;
    public float speed = 1.0f;
    private float storeSpeed = 1.0f;
    public Transform target;
    public GameObject enemy;
    public GameObject hitBox;
    private float playerHealth;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Enemy_Alive", true);
        range = range * range;
        attackRange = attackRange * attackRange;
        deadCheck = enemy.GetComponent<EnemyStats>().dead;
    }

    public void enemyDeath()
    {
        anim.SetBool("Enemy_Alive", false);
        Destroy(enemy, 3);
    }

    void follow()
    {
        anim.SetFloat("Enemy_Speed", 1.0f);
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void attack()
    {
        anim.SetBool("Enemy_Range", true);
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void dealDamage()
    {
        hitBox.SetActive(true);
    }

    void endDamage()
    {
        hitBox.SetActive(false);
    }

    void attackSlowDown()
    {
        storeSpeed = speed;
        speed = 1.0f;
    }

    void attackNormalSpeed()
    {
        speed = storeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        deadCheck = enemy.GetComponent<EnemyStats>().dead;
        playerHealth = enemy.GetComponent<EnemyStats>().player.GetComponent<PlayerStats>().currHealth;
        if(deadCheck)
        {
            enemyDeath();
        }
        else if(playerHealth > 0.0f)
        {
            float distance = (target.position - transform.position).sqrMagnitude;
            if(distance <= attackRange)
            {
                attack();
            }
            else if(distance <= range)
            {
                inRange = true;
                anim.SetBool("Enemy_Range", false);
                follow();
            }
            else
            {
                inRange = false;
                anim.SetFloat("Enemy_Speed", 0.0f);
                anim.SetBool("Enemy_Range", false);
            }
        }
        else
        {
            anim.SetFloat("Enemy_Speed", 0.0f);
            anim.SetBool("Enemy_Range", false);
        }
    }
}
