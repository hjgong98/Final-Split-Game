using UnityEngine;
using UnityEngine.SceneManagement;

// resume game: closes/destroys pause menu prefab and resumes game
// save game: opens save game panel
// credits: opens credits panel
// exit game: opens a warning panel 
//                  "do you want to save your game?" 
//                          yes - closes warning panel
//                          no - returns to main menu

// credits panel: credits, closes panel button
// save game panel: the 3 slots for save files, close panel button
//              if there is no save file
//                          the slot will say empty and it will be save panel 1 
//                          save the game to this slot? yes or no)
//              if the slot has a save file, the slot will have the name of the save fil
//              it will open save panel 2 (overwrite this save file? yes or no)

public class PauseMenu : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject saveGamePanel;
    public GameObject creditsPanel;
    public GameObject exitWarningPanel;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public AudioClip resumeSound;
    public AudioClip closePanelSound;
    public AudioClip exitGameSound;
    
    private LevelManager levelManager;
    
    void Start()
    {
        saveGamePanel.SetActive(false);
        creditsPanel.SetActive(false);
        exitWarningPanel.SetActive(false);
        
        levelManager = FindObjectOfType<LevelManager>();
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void OnResumeGame()
    {
        audioSource.PlayOneShot(resumeSound);
        
        if (levelManager != null)
        {
            levelManager.ResumeGameFromButton();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void OnSaveGame()
    {
        audioSource.PlayOneShot(buttonSound);
        saveGamePanel.SetActive(true);
    }
    
    public void OnCredits()
    {
        audioSource.PlayOneShot(buttonSound);
        creditsPanel.SetActive(true);
    }
    
    public void OnExitGame()
    {
        audioSource.PlayOneShot(buttonSound);
        exitWarningPanel.SetActive(true);
    }
    
    public void CloseSaveGamePanel()
    {
        audioSource.PlayOneShot(closePanelSound);
        saveGamePanel.SetActive(false);
    }
    
    public void CloseCreditsPanel()
    {
        audioSource.PlayOneShot(closePanelSound);
        creditsPanel.SetActive(false);
    }
    
    public void CloseExitWarningPanel()
    {
        audioSource.PlayOneShot(closePanelSound);
        exitWarningPanel.SetActive(false);
    }
    
    public void OnGoToStartMenu()
    {
        audioSource.PlayOneShot(exitGameSound);
        Time.timeScale = 1f;
        
        if (levelManager != null)
        {
            levelManager.ResumeGameFromButton();
        }
        
        SceneManager.LoadScene("Start Menu");
    }
}
