using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject glowLight;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("YO");
        if(other == player.GetComponent<BoxCollider>())
        {
            Debug.Log("HEY");
            if(Input.GetKeyDown("space"))
            {
                glowLight.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
