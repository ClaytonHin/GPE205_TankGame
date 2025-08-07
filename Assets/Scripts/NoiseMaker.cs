using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    // Create a public variable to store the total noiseVolume
    public float noiseVolume;
    // Create a public variable to store the decay rate per second of the noise
    public float noiseDecayPerSecond;

    // Update is called once per frame
    public void Update()
    {
        // Reduce the noise volume based on the decay rate, and delta time
        noiseVolume -= noiseDecayPerSecond * Time.deltaTime;
        // Check to ensure the noisevolume stays at 0
        if (noiseVolume < 0)
        {
            noiseVolume = 0;

        }
    }

    // Create a function for when an object should make noise
    public void MakeNoise(float amountOfNoiseMade)
    {
        // If the player made noise, then update our noise volume value
        noiseVolume = Mathf.Max(amountOfNoiseMade, noiseVolume);
    }
}
