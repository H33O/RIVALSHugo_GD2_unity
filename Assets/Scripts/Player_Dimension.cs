using UnityEngine;

public class PlayerDimension : MonoBehaviour
{
    public enum Dimension { Blue, Red }
    public Dimension currentDimension = Dimension.Blue;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleDimension();
            Debug.Log("changement");
        }
    }

    void ToggleDimension()
    {
        currentDimension = (currentDimension == Dimension.Blue) ? Dimension.Red : Dimension.Blue;
        DimensionManager.Instance.SwitchDimension(currentDimension);
    }
}