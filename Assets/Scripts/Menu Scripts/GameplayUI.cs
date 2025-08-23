using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    // Create a static instance of this class, as a singleton
    public static GameplayUI instance;
    // Create a variable to hold the score text UI 
    public TextMeshProUGUI scoreText;
    // Create a variable to hold the lives text UI
    public TextMeshProUGUI livesText;

    void Awake()
    {
        // If there is no instance of this class 
        if (instance == null)
        {
            // Set the instance
            instance = this;
        }
        else
        {
            // If there is already an instance, then destroy the previous one
            Destroy(gameObject);
        }
    }

    // Create a function to update the score text UI
    public void UpdateScoreText(int score)
    {
        // Update the score text UI, I know this is not optimized but it works for now
        scoreText.text = "Score: " + score.ToString();
    }

    // Create a function to update the lives text UI
    public void UpdateLivesText(int lives)
    {
        // If the text is not empty, then fill it with the lives data
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
