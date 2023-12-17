using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public float speed = 1f;
    private Transform player;
    public float retreatDistance = 10f;
    public float upwardForce = 500f;

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

        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, player.position) < 1f)
        {
            transform.Translate(-direction * retreatDistance * 3);
            EliminateAPet();
        }
    }

    void EliminateAPet()
    {
        GameObject[] pets = GameObject.FindGameObjectsWithTag("Pet");
        if (pets != null && pets.Length > 0)
        {
            pets[0].SetActive(false);
            speed++;
        }
        else 
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
