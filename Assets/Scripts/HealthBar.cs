using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float fillAmount = 1f;

    [SerializeField]
    private float lerpSpeed;
    
    [SerializeField]
    private Image content;

    public float MaxVal { get; set; }
    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxVal, 0, 1);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
