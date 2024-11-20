using UnityEngine;

public class TeleportCharacter : MonoBehaviour
{
    // Set the desired teleport positions
    public Vector3 teleportPosition1 = new Vector3(98.4f, 4.0f, 1.8f); // New location (adjusted Y value)
    private Vector3 teleportPosition2; // Original location

    private bool teleportToNewPosition = true;

    void Start()
    {
        // Store the initial position of the player
        teleportPosition2 = transform.position;
    }

    void Update()
    {
        // Check if the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle between teleport positions
            if (teleportToNewPosition)
            {
                transform.position = teleportPosition1;
            }
            else
            {
                transform.position = teleportPosition2;
            }

            // Switch the flag for the next teleport
            teleportToNewPosition = !teleportToNewPosition;
        }
    }
}
