using UnityEngine;

public class DamageData
{
    public float Amount { get; private set; }
    public GameObject Source { get; set; }

    public DamageData(float amount, GameObject source)
    {
        Amount = amount;
        Source = source;
    }

    public void SetAmount(float amount)
    {
        Amount = amount;
    }
}