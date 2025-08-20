using UnityEngine;

public class CreditsMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    public void BackToMenuButtonPressed()
    {
        // Save the options if they have changed

        // Transition back into the main menu state / screen
        GameManager.instance.ActivateMainMenu();
    }
}
