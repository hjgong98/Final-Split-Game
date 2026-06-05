using UnityEngine;

public class Knife : MonoBehaviour
{
    public Animator knifeAnimator;
    public bool isCutting;
    private Rect screenBounds;

    public float timeElapsed = 0f;
    private float clickTimeFrame = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = new Rect(0, 0, Screen.width, Screen.height - 200);
    }

    public void setCuttingState(bool state) {
        isCutting = state;
        knifeAnimator.SetBool("IsCutting", state);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0) && screenBounds.Contains(Input.mousePosition) && !isCutting) {
            timeElapsed = 0f;
            setCuttingState(true);
        } else {
            timeElapsed += Time.fixedDeltaTime;
            if(timeElapsed >= clickTimeFrame && isCutting) {
                setCuttingState(false);
                timeElapsed = 0f;
            }
        }
    }
}
