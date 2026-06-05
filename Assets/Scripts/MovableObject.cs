using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-Vector3.right * GameSystem.System.LEVEL.CurrentSpeed * Time.deltaTime, Space.World);
    }
}
