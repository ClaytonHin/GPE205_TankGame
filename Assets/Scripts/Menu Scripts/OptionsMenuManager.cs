using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenuManager : MonoBehaviour
{
    // Create an object to access the main volume slider value
    public Slider mainVolumeSlider;
    // Create an object to access the SFX volume slider value
    public Slider SFXVolumeSlider;
    // Create an object to access the music volume slider value
    public Slider musicVolumeSlider;
    // Create an object to access the audio mixer
    public AudioMixer audioMixer;
    // Create an object to access the split screen toggle value
    public Toggle splitScreenToggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // The OnEnable function is only called when the object becomes enabled within the scene
    private void OnEnable()
    {
        // Create a float to store the sliders values in a temporary variable
        float tempSliderValue;
        // Set the default values for the volume sliders
        audioMixer.GetFloat("VolumeMaster", out tempSliderValue);
        // Set our slider's value to the temporary variable's value
        mainVolumeSlider.value = tempSliderValue;
        // Get the default value for the music volume slider
        audioMixer.GetFloat("VolumeMusic", out tempSliderValue);
        // Set that value to our current slider value
        musicVolumeSlider.value = tempSliderValue;
        // Get the default value for the SFX volume slider
        audioMixer.GetFloat("VolumeSFX", out tempSliderValue);
        // Set that value to our current slider value
        SFXVolumeSlider.value = tempSliderValue;
    }

    // Create a function to handle the Back to Menu button being pressed
    public void BackToMenuButtonPressed()
    {
        // Save the options if they have changed

        // Transition back into the main menu state / screen
        GameManager.instance.ActivateMainMenu();
    }

    // Create a function to handle the Main/Master Volume slider being changed
    public void OnChangeMainVolume()
    {
        // Change the main volume within the audio mixer to match it to the slider's value
        audioMixer.SetFloat("VolumeMaster", mainVolumeSlider.value);
    }

    // Create a function to handle the SFX Volume slider being changed
    public void OnChangeSFXVolume()
    {
        // Change the SFX volume within the audio mixer to match it to the slider's value
        audioMixer.SetFloat("VolumeSFX", SFXVolumeSlider.value);
    }

    // Create a function to handle the Music Volume slider being changed
    public void OnChangeMusicVolume()
    {
        // Change the music volume within the audio mixer to match it to the slider's value
        audioMixer.SetFloat("VolumeMusic", musicVolumeSlider.value);
    }

    // Create a function to handle the Split Screen toggle being flipped
    public void OnChangeSplitScreenToggle()
    {
        // Set our toggle value to update the split screen value within the GameManager
        GameManager.instance.isSplitScreen = splitScreenToggle.isOn;
    }
}
