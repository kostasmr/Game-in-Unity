
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 80f;
    public float scrollSpeed = 20f;
    //public float minY = 20f;
    //public float maxY = 120f;

    //public Vector2 panLimit;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("e"))
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("x"))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.z += scroll * scrollSpeed * 100f * Time.deltaTime;
        //pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
        //pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}
