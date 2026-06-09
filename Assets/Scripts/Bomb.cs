using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public int scorePenalty = 50;
    private bool triggered = false;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        // ONLY react to Cutter (same as your fruit system)
        Cutter cutter = other.GetComponent<Cutter>();
        if (cutter == null) return;

        Knife knife = cutter.Knife.GetComponent<Knife>();
        if (knife == null) return;

        if (!knife.isCutting) return;

        triggered = true;

        // stop movement
        var mover = GetComponent<MovableObject>();
        if (mover != null)
            mover.enabled = false;

        GameSystem.System.LEVEL.ApplyBombPenalty(scorePenalty);

        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        var r = GetComponent<MeshRenderer>();
        if (r != null)
            r.material.color = Color.red;

        yield return new WaitForSeconds(0.15f);

        Destroy(gameObject);
    }
}