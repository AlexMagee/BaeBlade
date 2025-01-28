using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField]
    private HealthBar bar;
    [SerializeField]
    private float currentVal;
    [SerializeField]
    private float maxVal;
    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = Mathf.Clamp(value, 0, MaxVal);
            bar.Value = currentVal;
        }
    }
    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            this.maxVal = value;
            bar.MaxVal = maxVal;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
