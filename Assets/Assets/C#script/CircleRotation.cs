using UnityEngine;
using UnityEngine.UI;

public class CircleRotationWithDistance : MonoBehaviour
{
    public float baseRotationSpeed = 100f;  // Base rotation speed
    private bool isClockwise = true;        // Rotation direction flag

    // Reference to the button in the UI
    public Button toggleButton;

    // Reference to the point from which distance is measured
    public Transform referencePoint;

    // Update rotation based on distance
    void Update()
    {
        // Calculate the distance between the circle and the reference point
        float distance = Vector3.Distance(transform.position, referencePoint.position);

        // Adjust the rotation speed based on the distance (can customize the formula)
        float rotationSpeed = baseRotationSpeed / distance;

        // Rotate the circle based on the current direction and distance-adjusted speed
        if (isClockwise)
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime); // Clockwise rotation
        }
        else
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);  // Counterclockwise rotation
        }
    }

    // Start method to add listener to the button
    void Start()
    {
        // Add a listener to the button to trigger rotation direction toggle
        toggleButton.onClick.AddListener(ToggleRotation);
    }

    // Method to toggle the rotation direction
    void ToggleRotation()
    {
        isClockwise = !isClockwise;
    }
}
