using UnityEngine;

public class PlayerDimension : MonoBehaviour
{
    public BoxCollider blueCollider;
    public BoxCollider redCollider;
    public MeshRenderer meshRenderer;
    
    [Header("Dimension Colors")]
    [SerializeField] private Color _blueColor;
    [SerializeField] private Color _redColor;
    
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
            blueCollider.transform.localPosition = new Vector3(0f, 0f, 0f);
            redCollider.transform.localPosition = new Vector3(0f, -5f, 0f);
            meshRenderer.material.color = _blueColor;
        }
        else
        {
            redCollider.transform.localPosition = new Vector3(0f, 0f, 0f);
            blueCollider.transform.localPosition = new Vector3(0f, -5f, 0f);
            meshRenderer.material.color = _redColor;
        }
    }
}