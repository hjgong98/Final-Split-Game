using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.World);
    }
}
