using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AudioSpectrumAnalyzer : MonoBehaviour
{
    public int resolution = 512;
    public float sensitivity = 100.0f;
    public float decaySpeed = 0.01f;
    public float[] spectrum;

    public int startFrequency = 0;
    public int endFrequency = 100;
    public Color spriteColor = Color.white;

    public int numberOfSprites = 3;
    public float spriteSpacing = 1.0f;
    public GameObject spritePrefab;

    public float maxHeight = 2.0f;
    public float minHeight = 0.1f;

    public float smoothingFactor = 0.1f; // Add new parameter

    private List<GameObject> sprites = new List<GameObject>();
    private float[,] previousScaleValues;
    private float[,] currentScaleValues;

    void Start()
    {
        spectrum = new float[resolution];

        // Create multiple sprites and position them in a line
        for (int i = 0; i < numberOfSprites; i++)
        {
            GameObject spriteObject = Instantiate(spritePrefab, transform);
            spriteObject.transform.localScale = Vector3.one;
            SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = spriteColor;
            Vector3 position = new Vector3(i * spriteSpacing, 0, 0);
            spriteObject.transform.localPosition = position;
            sprites.Add(spriteObject);
        }

        // Initialize arrays for current and previous scale values
        previousScaleValues = new float[numberOfSprites, 2];
        currentScaleValues = new float[numberOfSprites, 2];
    }

    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hanning);
        for (int i = 0; i < numberOfSprites; i++)
        {
            GameObject spriteObject = sprites[i];
            SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
            float spriteHeight = spriteRenderer.sprite.bounds.size.y * spriteObject.transform.localScale.y;
            float spriteScale = spectrum[i * (endFrequency - startFrequency) / numberOfSprites + startFrequency] * sensitivity * Time.deltaTime / decaySpeed;

            // Update current and previous scale values using EMA
            currentScaleValues[i, 0] = Mathf.Lerp(previousScaleValues[i, 0], spriteScale, smoothingFactor);
            currentScaleValues[i, 1] = Mathf.Lerp(previousScaleValues[i, 1], spriteHeight, smoothingFactor);
            previousScaleValues[i, 0] = currentScaleValues[i, 0];
            previousScaleValues[i, 1] = currentScaleValues[i, 1];

            float spriteScaleSmooth = currentScaleValues[i, 0]; // Use smoothed scale value
            spriteScaleSmooth = Mathf.Lerp(minHeight, maxHeight, spriteScaleSmooth);
            spriteObject.transform.localScale = new Vector3(spriteObject.transform.localScale.x, spriteScaleSmooth, spriteObject.transform.localScale.z);

            //float spriteYPosSmooth = Mathf.Lerp(0, currentScaleValues[i, 1], spriteScaleSmooth / spriteHeight); // Calculate Y position using smoothed scale value
            //spriteObject.transform.localPosition = new Vector3(spriteObject.transform.localPosition.x, spriteYPosSmooth, spriteObject.transform.localPosition.z);
        }
    }
}


