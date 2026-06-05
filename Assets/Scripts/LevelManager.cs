using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenuPrefab;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip openPauseSound;
    
    private GameObject currentPauseMenu;
    private bool isPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    private void PauseGame()
    {
        audioSource.PlayOneShot(openPauseSound);
        audioSource.enabled = false;
        
        Time.timeScale = 0f;
        
        currentPauseMenu = Instantiate(pauseMenuPrefab);
        isPaused = true;
    }
    
    private void ResumeGame()
    {
        if (currentPauseMenu != null)
        {
            Destroy(currentPauseMenu);
            currentPauseMenu = null;
            isPaused = false;
            audioSource.enabled = true;
            Time.timeScale = 1f;
        }
    }
    
    public void ResumeGameFromButton()
    {
        ResumeGame();
    }
}
