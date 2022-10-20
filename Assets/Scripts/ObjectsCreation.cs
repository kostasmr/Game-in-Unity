using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCreation : MonoBehaviour
{
    public PhysicMaterial mats;
    public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        sounds[0] = (AudioClip)Resources.Load("Sounds/ObjCrash");
        sounds[1] = (AudioClip)Resources.Load("Sounds/BackgroundSound");
        source.clip = sounds[1];
        source.volume = 0.1f;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            create();
        }
    }

    public void create()
    { 
        int x = Random.Range(0, 3);
        float scale = Random.Range(1.0f, 10.0f);
        float pos = scale / 2;

        if (x == 0)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(scale, scale, scale);
            cube.transform.position = new Vector3(pos, pos, pos);
            Renderer rend = cube.GetComponent<Renderer>();
            rend.enabled = true;
            rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            cube.AddComponent<ObjectMovement>();
            Rigidbody rb = cube.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            BoxCollider col = cube.GetComponent<BoxCollider>();
            col.material = (PhysicMaterial)Resources.Load("PhysicMaterials/mat1");
            AudioSource source = cube.AddComponent<AudioSource>();
            source.clip = sounds[0];
            source.playOnAwake = false;
            source.volume = 0.3f;
        }
        if (x == 1)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(scale, scale, scale);
            sphere.transform.position = new Vector3(pos, pos, pos);
            Renderer rend = sphere.GetComponent<Renderer>();
            rend.enabled = true;
            rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            sphere.AddComponent<ObjectMovement>();
            Rigidbody rb = sphere.AddComponent<Rigidbody>();
            SphereCollider col = sphere.GetComponent<SphereCollider>();
            rb.useGravity = false;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            col.material = (PhysicMaterial)Resources.Load("PhysicMaterials/mat1");
            AudioSource source = sphere.AddComponent<AudioSource>();
            source.clip = sounds[0];
            source.playOnAwake = false;
            source.volume = 0.3f;
        }
        if (x == 2)
        {
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.localScale = new Vector3(scale, scale, scale);
            cylinder.transform.position = new Vector3(pos, scale, pos);
            Renderer rend = cylinder.GetComponent<Renderer>();
            rend.enabled = true;
            rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            cylinder.AddComponent<ObjectMovement>();
            Rigidbody rb = cylinder.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            CapsuleCollider col = cylinder.GetComponent<CapsuleCollider>();
            col.material = (PhysicMaterial)Resources.Load("PhysicMaterials/mat1");
            AudioSource source = cylinder.AddComponent<AudioSource>();
            source.clip = sounds[0];
            source.playOnAwake = false;
            source.volume = 0.3f;
        }
    }
}
