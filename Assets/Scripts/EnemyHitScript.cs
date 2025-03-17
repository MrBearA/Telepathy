using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            Destroy(gameObject);
        }
    }
}
