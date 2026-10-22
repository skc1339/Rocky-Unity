using UnityEngine;

public class RockyMove : MonoBehaviour
{
    public float speed = 1f;
    public float pauseTime = 0.5f;
    public float leftLimit = -3f;
    public float rightLimit = 3f;
    public float turnSpeed = 8f;

    private float direction = 1f;
    private float pauseTimer = 0f;
    private bool isPaused = false;

    void Update()
    {
        Quaternion targetRotation = direction > 0f
            ? Quaternion.Euler(0f, 0f, 0f)
            : Quaternion.Euler(0f, 180f, 0f);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        if (isPaused)
        {
            pauseTimer += Time.deltaTime;

            if (pauseTimer >= pauseTime)
            {
                pauseTimer = 0f;
                isPaused = false;
                direction *= -1f;
            }

            return;
        }

        transform.Translate(Vector3.right * speed * direction * Time.deltaTime, Space.World);

        if (transform.position.x >= rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
            isPaused = true;
        }
        else if (transform.position.x <= leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
            isPaused = true;
        }
    }
}