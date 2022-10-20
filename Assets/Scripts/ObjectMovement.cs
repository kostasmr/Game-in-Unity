using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float vx;
    public float vy;
    public float vz;
    public Rigidbody rb;
    public Vector3 movement;
    public float speed = 40.0f;
    public Renderer rend;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        vx = Random.Range(0.1f, 1.0f);
        vy = Random.Range(0.1f, 1.0f);
        vz = Random.Range(0.1f, 1.0f);
        movement = new Vector3(vx, vy, vz);
        rb = this.GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(","))
        {
            speed -= 10f;
        }
        if (Input.GetKeyDown("."))
        {
            speed += 10f;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Sphere")
        {
            rend.material.color = Color.red;
            source.Play();
        }
        if (col.gameObject.tag == "Cube")
        { 
            rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            source.Play();
        }
        if (col.gameObject.name == "First Person Player")
        {
            rend.material.color = Color.cyan;
            source.Play();
        }
        ReflectProjectile(rb, col.contacts[0].normal);
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
        movement = Vector3.Reflect(movement, reflectVector);
        moveCharacter(movement);
    }
}
