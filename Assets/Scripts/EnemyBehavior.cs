using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public bool isBlueEnemy = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ✅ Ici on récupère la dimension actuelle
            var currentDimension = DimensionManager.Instance.CurrentDimension;

            bool playerIsDangerous =
                (currentDimension == PlayerDimension.Dimension.Blue && isBlueEnemy) ||
                (currentDimension == PlayerDimension.Dimension.Red && !isBlueEnemy);

            if (playerIsDangerous)
            {
                Debug.Log("L’ennemi est mangé !");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Le joueur est mangé !");
            }
        }
    }
}