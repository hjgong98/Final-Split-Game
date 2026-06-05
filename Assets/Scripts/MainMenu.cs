using UnityEngine;
using UnityEngine.SceneManagement;

//play game - start game at MainScene
//load game - open load game panel
//credits - open credits panel
//exit game - exit game

//credits panel - credits, close panel
//load game panel - 3 save files, close panel



public class MainMenu : MonoBehaviour
{
    [Header("Panel References")]
    public GameObject loadGamePanel;
    public GameObject creditsPanel;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public AudioClip panelCloseSound;
    
    void Start()
    {
        loadGamePanel.SetActive(false);
        creditsPanel.SetActive(false);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void OnPlayGame()
    {
        audioSource.PlayOneShot(buttonClickSound);
        SceneManager.LoadScene("MainScene");
    }
    
    public void OnLoadGame()
    {
        audioSource.PlayOneShot(buttonClickSound);
        loadGamePanel.SetActive(true);
    }
    
    public void OnCredits()
    {
        audioSource.PlayOneShot(buttonClickSound);
        creditsPanel.SetActive(true);
    }
    
    public void OnExitGame()
    {
        audioSource.PlayOneShot(buttonClickSound);
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    public void CloseLoadGamePanel()
    {
        audioSource.PlayOneShot(panelCloseSound);
        loadGamePanel.SetActive(false);
    }
    
    public void CloseCreditsPanel()
    {
        audioSource.PlayOneShot(panelCloseSound);
        creditsPanel.SetActive(false);
    }
}
