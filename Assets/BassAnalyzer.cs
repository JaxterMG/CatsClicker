using UnityEngine;

public class BassAnalyzer : MonoBehaviour
{
    public int resolution = 512;
    public float sensitivity = 100.0f;
    public float decaySpeed = 0.01f;
    public float[] spectrum;
    public float bassValue;

    void Start()
    {
        spectrum = new float[resolution];
    }

    void FixedUpdate()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hanning);
        
        // Calculate the sum of the frequency bins corresponding to the bass range
        int startFrequency = 20;
        int endFrequency = 250;
        int startIndex = (int)Mathf.Floor(startFrequency * resolution / AudioSettings.outputSampleRate);
        int endIndex = (int)Mathf.Ceil(endFrequency * resolution / AudioSettings.outputSampleRate);
        float bassSum = 0.0f;
        for (int i = startIndex; i <= endIndex; i++)
        {
            bassSum += spectrum[i];
        }

        // Normalize the bass value by dividing by the number of bins in the bass range
        int numBins = endIndex - startIndex + 1;
        bassValue = bassSum * sensitivity * Time.deltaTime / (decaySpeed * numBins);
    }
}