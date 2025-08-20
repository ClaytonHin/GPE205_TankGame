using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Create a function to handle the Start button being pressed
    public void OnStartButtonPressed()
    {
        // Change the state to the gameplay state / screen
        GameManager.instance.ActivateGameplay();
    }

    // Create a function to handle the Credits button being pressed
    public void OnCreditsButtonPressed()
    {
        // Change the state to the credits state / screen
        GameManager.instance.ActivateCreditsMenu();
    }

    // Create a function to handle the Options button being pressed
    public void OnOptionsButtonPressed()
    {
        // Change the state to the options state / screen
        GameManager.instance.ActivateOptionsMenu();
    }

    // Create a function to handle the Quit button being pressed
    public void OnQuitButtonPressed()
    {
        // Exit the application/game
        Application.Quit();
    }
}
