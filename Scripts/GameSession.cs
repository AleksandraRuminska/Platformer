using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    PlayerMovement player;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1){
            Destroy(gameObject);
        } else{
            DontDestroyOnLoad(gameObject);
        }
        
        player = FindObjectOfType<PlayerMovement>();
     
    }

    void Start(){
        livesText.text = playerLives.ToString();
        scoreText.text = playerScore.ToString();

    }

    public void ProcessPlayerDeath(){
        if (playerLives > 1){
            TakeLife();
        } else{
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd){
        playerScore += pointsToAdd;
        scoreText.text = playerScore.ToString();

    }

    void TakeLife(){
        playerLives--;
        livesText.text = playerLives.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ResetGameSession(){
        // FindObjectOfType<ScenePersists>().ResetScenePersist();
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
