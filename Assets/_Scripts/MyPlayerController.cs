using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class MyPlayerController : MonoBehaviour {
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawnTransform;

    public float fireRate;
    private float nextFire;

    private void Start()
    {
        nextFire = Time.time;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(
                shot,
                shotSpawnTransform.position,
                shotSpawnTransform.rotation
            );
        }

        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        var rigidBody = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.velocity = movement;

        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidBody.rotation = Quaternion.Euler
        (
            0f,
            0f,
            rigidBody.velocity.x * -tilt
        );
    }
}
