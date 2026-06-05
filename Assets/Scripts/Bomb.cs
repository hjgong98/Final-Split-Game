using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public int scorePenalty = 50;
    private bool hasBeenHit = false;

    void OnTriggerStay(Collider collidedObj) {
        if (hasBeenHit) return;
        if (collidedObj.name != "Cutter") return;

        Knife knife = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Knife>();
        if (knife == null || !knife.isCutting) return;

        hasBeenHit = true;
        GameSystem.System.LEVEL.ApplyBombPenalty(scorePenalty);
        StartCoroutine(ShakeBomb());
    }

    IEnumerator ShakeBomb() {
        MovableObject movable = GetComponent<MovableObject>();
        movable.enabled = false;

        Vector3 origin = transform.position;
        float duration = 0.5f;
        float elapsed = 0f;
        float magnitude = 40f;

        while (elapsed < duration) {
            transform.position = new Vector3(
                origin.x + Random.Range(-magnitude, magnitude),
                origin.y + Random.Range(-magnitude, magnitude),
                origin.z
            );
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = origin;
        movable.enabled = true;
    }
}