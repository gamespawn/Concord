using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public const float YAngle_Min = 10.0f;
    public const float YAngle_Max = 50.0f;
    public GameObject gamemanager;
    public Transform lookAt;
    public Transform camTransform;
    public Camera cam;
    public float distance = 10.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    // Start is called before the first frame update    
    void Start()
    {
        camTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.GetComponent<gamemanager>().gameStart == true)
        {
            currentX -= Input.GetAxis("Mouse X");
            currentY -= Input.GetAxis("Mouse Y");

            currentY = Mathf.Clamp(currentY,YAngle_Min,YAngle_Max);
        }
    }

    void LateUpdate()
    {
        if(gamemanager.GetComponent<gamemanager>().gameStart == true)
        {
            Vector3 dir = new Vector3(0,0,-distance);
            Quaternion rotation = Quaternion.Euler(currentY,currentX,0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);
        }
    }
}
