using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float cameraSensitivity = 90;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        if (Input.GetKey("e"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("x"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        transform.position = pos;
         
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            transform.position += transform.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
    }
}
