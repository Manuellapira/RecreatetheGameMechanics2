using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float moveSpeed = 2f;  // Speed at which the object moves
    public Vector2 direction = Vector2.left; // Default direction (left)

    void Update()
    {
        // Move the object slowly in the specified direction
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Destroy the object if it goes off-screen
        if (transform.position.x < -10f) // Customize this based on your screen size
        {
            Destroy(gameObject);
        }
    }
}
