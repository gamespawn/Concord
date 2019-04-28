using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    List<GameObject> leftDoorRooms;
    List<GameObject> rightDoorRooms;
    List<GameObject> forwardDoorRooms;
    List<GameObject> backwardDoorRooms;

    public GameObject slimeIntro;
    public GameObject waspIntro;
    public GameObject warriorIntro;
    public GameObject keyRoom;
    public GameObject bossEntrance;
    public GameObject crossRoom;
    public GameObject verticalRoom;
    public GameObject horizontalRoom;
    public GameObject leftDeadEnd;
    public GameObject rightDeadEnd;
    public GameObject forwardDeadEnd;
    public GameObject backwardDeadEnd;

    // Start is called before the first frame update
    void Start()
    {
        leftDoorRooms = new List<GameObject>();
        rightDoorRooms = new List<GameObject>();
        forwardDoorRooms = new List<GameObject>();
        backwardDoorRooms = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
