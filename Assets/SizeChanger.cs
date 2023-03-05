using UnityEngine;

public class SizeChanger : MonoBehaviour
{
   public BassAnalyzer bassAnalyzer;
    public float minScale = 1.0f;
    public float maxScale = 2.0f;
    public float smoothing = 5.0f;

    public float CurrentScale;

    void Start()
    {
        CurrentScale = transform.localScale.x;
    }

    void Update()
    {
        float targetScale = Mathf.Lerp(minScale, maxScale, bassAnalyzer.bassValue);
        CurrentScale = Mathf.Lerp(CurrentScale, targetScale, Time.deltaTime * smoothing);
        transform.localScale = new Vector3(CurrentScale, CurrentScale, CurrentScale);
    }
}
