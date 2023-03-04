using UnityEngine;

public class SizeChanger : MonoBehaviour
{
   public BassAnalyzer bassAnalyzer;
    public float minScale = 1.0f;
    public float maxScale = 2.0f;
    public float smoothing = 5.0f;

    private float currentScale;

    void Start()
    {
        currentScale = transform.localScale.x;
    }

    void Update()
    {
        float targetScale = Mathf.Lerp(minScale, maxScale, bassAnalyzer.bassValue);
        currentScale = Mathf.Lerp(currentScale, targetScale, Time.deltaTime * smoothing);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
