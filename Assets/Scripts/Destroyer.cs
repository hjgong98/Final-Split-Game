using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider collidedObj)
    {
        Destroy(collidedObj.gameObject);
    }
}
