using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    Vector3 randomAngle;
    public GameObject Knife;
    
    void OnTriggerEnter(Collider collidedObj) {
        if (collidedObj.gameObject.tag == "Slice" && Knife.GetComponent<Knife>().isCutting)
        {
            collidedObj.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collidedObj.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.up * 8900f, ForceMode.Impulse);
            randomAngle = new Vector3(Random.Range(-0.3f, -0.6f), Random.Range(0.2f, 0.3f), Random.Range(-0.5f, 0.5f));

            collidedObj.gameObject.GetComponent<Rigidbody>().AddForce(randomAngle * Random.Range(650, 1500), ForceMode.Impulse);
            Knife.GetComponent<Knife>().setCuttingState(true);
            GameSystem.System.LEVEL.OnVegetableCut();

            Destroy(collidedObj.gameObject, 4f);
            Destroy(collidedObj.gameObject.transform.parent.gameObject, 4f);
        }
    }
}
