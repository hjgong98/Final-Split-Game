using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{

    public GameObject Knife;
    public Animator Animator;
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit)) {
            if (hit.collider.tag == "Obstacle" && Knife.GetComponent<Knife>().isCutting) {
                Debug.Log("Hit");
                Animator.SetBool("IsHit", true);
            }
        }
    }
}
