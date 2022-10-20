using UnityEngine;
using System.Collections;

public class SphereController : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody rb;
    public Vector3 movement;

    public float minX = 7.5f;
    public float maxX = 92.5f;
    public float minY = 7.5f;
    public float maxY = 92.5f;
    public float minZ = 7.5f;
    public float maxZ = 92.5f;

    //select a texure
    public Material[] mats;
    Renderer rend;
    public int count_t = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        rend.enabled = true;
        rend.sharedMaterial = mats[0];
        mats[0] = (Material)Resources.Load("Materials/Sphere_big");
        mats[1] = (Material)Resources.Load("Materials/Sphere_texture");
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = rb.transform.position;
        
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKey("up"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("-"))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("="))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SelectTexture();
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        rb.transform.position = pos;
    }

    public void SelectTexture()
    {
        count_t++;
        if (count_t % 2 != 0)
        {
            rend.sharedMaterial = mats[1];
        }
        else
        {
            rend.sharedMaterial = mats[0];
        }
    }
}
