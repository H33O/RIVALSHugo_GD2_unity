using UnityEngine;

public class PlayerDimension : MonoBehaviour
{
    public BoxCollider blueCollider;
    public BoxCollider redCollider;
    public MeshRenderer meshRenderer;
    private bool isBlueDimension = true;

    void Start()
    {
        SetDimension(isBlueDimension);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isBlueDimension = !isBlueDimension;
            SetDimension(isBlueDimension);
            Debug.Log("Dimension changée : " + (isBlueDimension ? "Bleue" : "Rouge"));
        }
    }

    void SetDimension(bool blue)
    {
        if (blue)
        {
            // Blue actif
            blueCollider.transform.localPosition =new Vector3(0f, 0f, 0f);   // sur la carte
            redCollider.transform.localPosition =new Vector3(0f, -5f, 0f); // sous la carte
            meshRenderer.material.color = Color.cyan;
            
        }
        else
        {
            // Red actif
            redCollider.transform.localPosition =new Vector3(0f, 0f, 0f);
            blueCollider.transform.localPosition =new Vector3(0f, -5f, 0f);
            meshRenderer.material.color = Color.red;
        }
    }
}