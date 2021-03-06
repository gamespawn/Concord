﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform target;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("HELLO");
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
