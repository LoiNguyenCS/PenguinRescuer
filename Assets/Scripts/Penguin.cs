using UnityEngine;
using UnityEngine.SceneManagement;

public class Penguin : MonoBehaviour
{
    private float moveSpeed = 3f; 
    private float rotationSpeed = 90f; 
    private float turnTimer = 0f;
    private float turnTimeThreshold = 1f; 
    private Transform player;

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
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        turnTimer += Time.deltaTime;

        if (turnTimer >= turnTimeThreshold)
        {
            transform.Rotate(Vector3.up * rotationSpeed);

            turnTimer = 0f;
        }
        CheckWinState();
    }

    void CheckWinState()
    {    
        float distance = Vector3.Distance(transform.position, player.position);
        Debug.Log(distance + "/" + 1);    
        if (Vector3.Distance(transform.position, player.position) < 2.5f)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
