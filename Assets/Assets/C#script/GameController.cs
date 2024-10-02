using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int score = 0;                 // Player's score
    public TextMeshProUGUI scoreText;     // Reference to the TMP UI text for the score
    public GameObject gameOverPanel;      // Reference to the game over UI

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        // Initialize the score display
        UpdateScore();
        gameOverPanel.SetActive(false);   // Ensure game over panel is hidden at the start
    }

    // This method updates the score UI text
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    // Method to handle collision with collectibles or obstacles
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            // Collect the item, increase score, and destroy collectible
            score += 1;
            UpdateScore();
            Destroy(other.gameObject);  // Remove collectible from the scene
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // Trigger Game Over
            GameOver();
        }
    }

    // Method to handle Game Over logic
    public void GameOver()
    {
        gameOverPanel.SetActive(true);   // Display game over UI
        Time.timeScale = 0;              // Freeze the game
    }

    // Optionally, add a method to restart the game or go back to the main menu
    public void RestartGame()
    {
        Time.timeScale = 1;              // Resume game speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current scene
    }
}
