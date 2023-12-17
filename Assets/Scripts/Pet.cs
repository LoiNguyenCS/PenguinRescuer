using UnityEngine;

public class Pet : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;
    public float stopDistance = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure to tag your player object with 'Player'");
        }
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0; 
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stopDistance)
        {
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(Vector3.zero);
        }
    }
}
