using UnityEngine;

public class AntiVirus : MonoBehaviour
{
    private const float BONUS_DURATION = 7f;
    private const float HIDDEN_Y_POSITION = -5f;
    private const float ACTIVE_Y_POSITION = 0.5f;

    [SerializeField] private GameObject antiVirusZone;
    
    private float antiVirusEndTime;
    private bool isAntiVirusActive = false;

    private void Start()
    {
        if (antiVirusZone == null)
        {
            antiVirusZone = transform.Find("AntiVirus")?.gameObject;
            
            if (antiVirusZone == null)
            {
                Debug.LogError("AntiVirus: L'objet enfant 'AntiVirus' n'a pas été trouvé !");
                return;
            }
        }
        
        antiVirusZone.transform.localPosition = new Vector3(0f, HIDDEN_Y_POSITION, 0f);
        antiVirusZone.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AntiVirus"))
        {
            ActivateAntiVirus();
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (isAntiVirusActive && Time.time >= antiVirusEndTime)
        {
            DeactivateAntiVirus();
        }
    }

    private void ActivateAntiVirus()
    {
        antiVirusZone.SetActive(true);
        antiVirusZone.transform.localPosition = new Vector3(0f, ACTIVE_Y_POSITION, 0f);
        antiVirusEndTime = Time.time + BONUS_DURATION;
        isAntiVirusActive = true;
        
        Debug.Log("AntiVirus activé pour " + BONUS_DURATION + " secondes !");
    }

    private void DeactivateAntiVirus()
    {
        antiVirusZone.transform.localPosition = new Vector3(0f, HIDDEN_Y_POSITION, 0f);
        antiVirusZone.SetActive(false);
        isAntiVirusActive = false;
        
        Debug.Log("AntiVirus désactivé !");
    }
}

