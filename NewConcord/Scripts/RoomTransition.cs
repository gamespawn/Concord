using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RoomTransition : MonoBehaviour
{
    public bool enteredBefore = false;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(player);
    }

    public void newRoom()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if ((other == player.GetComponent<BoxCollider>()) && (enteredBefore == false))
        {
            enteredBefore = true;
            newRoom();
        }
    }
}
