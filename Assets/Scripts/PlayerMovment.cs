using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float playerSpeed = 6f;
    public float horizontalSpeed = 3f;
    public float maxSpeed = 180f;
    public float speedIncreaseRate = 0.5f;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;
    [SerializeField] bool isRunning;

    void Update()
    {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }

        // Gradually increase both speeds up to max
        if (playerSpeed < maxSpeed)
        {
            playerSpeed += speedIncreaseRate * Time.deltaTime;
            horizontalSpeed = playerSpeed * 0.5f;
        }

        // Forward movement
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        // Left movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }

        // Right movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.35f);
        MasterInfo.distanceRun += 1;
        isRunning = false;
    }
}