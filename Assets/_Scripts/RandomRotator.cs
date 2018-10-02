using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;

    private void Start()
    {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
        rigidBody.angularDrag = 0;
    }
}
