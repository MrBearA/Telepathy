using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private Transform playerTransform;

    private void Update()
    {
        if (playerTransform != null)
        {
            MoveTowardsPlayer();
        }
        else
        {
            FindPlayer();
        }
    }

    private void FindPlayer()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        transform.Translate(directionToPlayer * speed * Time.deltaTime);
    }
}
