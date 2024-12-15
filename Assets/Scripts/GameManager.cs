using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Game Objects
    public GameObject playButton;
    public GameObject airplane;
    public GameObject enemySpawner;
    public GameObject gameOverSprite;    // GameOver Image
    public GameObject gameOverButton;    // GameOver Button
    public GameObject userScore;    // Score UI
    public GameObject gameTimer;    // Timer
    public GameObject gameTitle;    // Title

    public enum GameStates
    {
        Opening, GamePlay, GameOver
    }

    // Make gameStates public so other scripts can access it directly
    public GameStates gameStates;

    // Use this for initialization
    void Start()
    {
        // Initialize game state to Opening by default
        gameStates = GameStates.Opening;
        UpdateGameStates();
    }

    // Update game state
    void UpdateGameStates()
    {
        switch (gameStates)
        {
            case GameStates.GameOver:
                // Stop time
                gameTimer.GetComponent<TimeCounter>().stopTimeCounter();
                // Stop enemy spawn
                enemySpawner.GetComponent<EnemySpawner>().StopEnemySpawn();
                // Show GameOver screen
                gameOverSprite.SetActive(true);
                // Show GameOver button
                gameOverButton.SetActive(true);
                // Change game state to Opening after 8 seconds
                Invoke("SetGameStateToOpening", 8f);
                break;
            case GameStates.GamePlay:
                // Reset score
                userScore.GetComponent<GameScore>().Score = 0;
                // Hide button
                playButton.SetActive(false);
                gameTitle.SetActive(false);
                // Initialize player
                airplane.GetComponent<UserControll>().Init();
                // Start enemy spawn
                enemySpawner.GetComponent<EnemySpawner>().StartEnemySpawn();
                // Start timer
                gameTimer.GetComponent<TimeCounter>().startTimeCounter();
                break;
            case GameStates.Opening:
                // Stop showing GameOver screen
                gameOverSprite.SetActive(false);
                gameOverButton.SetActive(false);  // Hide GameOver button
                // Enable Play button
                playButton.SetActive(true);
                gameTitle.SetActive(true);
                break;
        }
    }

    // Set game state method
    public void SetGameState(GameStates state)
    {
        gameStates = state;
        UpdateGameStates();
    }

    // Start the game on button press
    public void StartGamePlay()
    {
        gameStates = GameStates.GamePlay;
        UpdateGameStates();
    }

    // Set game state to Opening
    public void SetGameStateToOpening()
    {
        SetGameState(GameStates.Opening);
    }
}
