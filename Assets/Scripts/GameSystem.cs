using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameSystem : MonoBehaviour
{
    static GameSystem _system;

    public GameObject GameScoreCanvas;
    public GameObject EndGameCanvas;
    public TextMeshProUGUI EndScoreText;
    public static GameSystem System {
        get {
            if (_system == null) {
                _system = GameObject.FindObjectOfType<GameSystem>();
                if(_system == null) {
                    GameObject container = new GameObject("GameSystem");
                    _system = container.AddComponent<GameSystem>();
                }
            }
            return _system;
        }
    }

    public void OnRestart() {
        EndGameCanvas.SetActive(true);
        GameScoreCanvas.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    public void OnKnifeKill() {
        EndScoreText.text = LEVEL.Score.ToString();
        EndGameCanvas.SetActive(true);
        GameScoreCanvas.SetActive(false);
    }
    public Level LEVEL;
}

[System.Serializable]
public class Level {
    public float CurrentSpeed = 600;
    public int Score = 0;

    public TextMeshProUGUI ScoreText;
    public void IncreaseScore() {
        Score += 1;
        ScoreText.text = Score.ToString();
        float speed = CurrentSpeed;
        if(CurrentSpeed != 1200) {   
            if(Score >= 200) {
                speed = 900;
            }
            if (Score >= 400) {
                speed = 1200;
            }

            UpdateLevelSpeed(speed);
        }
    }

    private void UpdateLevelSpeed(float speed) {
        ObjectSpawner spawner = GameObject.FindObjectOfType<ObjectSpawner>();
        Animator knifeAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        if(speed == 900) {
            spawner.spawnInterval = 0.4f;
            knifeAnimator.SetFloat("Speed", 2.0f);
        }
        if(speed == 1200) {
            spawner.spawnInterval = 0.25f;
            knifeAnimator.SetFloat("Speed", 2.5f);
        }
        CurrentSpeed = speed;
    }

    public void ApplyBombPenalty(int amount) {
        Score -= amount;
        Score = Mathf.Max(0, Score);
        ScoreText.text = Score.ToString();
    }

    public void OnVegetableCut() {
        IncreaseScore();
    }
}
