using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider collidedObj)
    {
        if (collidedObj.tag == "Slice" || collidedObj.tag == "Obstacle") {
            Destroy(collidedObj.gameObject.transform.parent.gameObject);
        } else if (collidedObj.tag == "Bomb") {
            Destroy(collidedObj.gameObject);
        }
    }
}
