using UnityEngine;
using System;

public class DimensionManager : MonoBehaviour
{
    public static DimensionManager Instance;

    public static event Action<PlayerDimension.Dimension> OnDimensionChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SwitchDimension(PlayerDimension.Dimension newDimension)
    {
        Debug.Log("DimensionManager: switch to " + newDimension);
        OnDimensionChanged?.Invoke(newDimension);
    }
}