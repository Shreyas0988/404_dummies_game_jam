using UnityEngine;

public class ContinuousCollisionChecker : MonoBehaviour
{
    private bool isColliding = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the other object has the "ObjectGrabbable" script
        ObjectGrabbable grabbable = collision.gameObject.GetComponent<ObjectGrabbable>();
        if (grabbable != null)
        {
            isColliding = true;
            Debug.Log($"Started colliding with: {collision.gameObject.name}");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Keep checking during the collision
        ObjectGrabbable grabbable = collision.gameObject.GetComponent<ObjectGrabbable>();
        if (grabbable != null && isColliding)
        {
            Debug.Log($"Still colliding with: {collision.gameObject.name}");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the collision has ended
        ObjectGrabbable grabbable = collision.gameObject.GetComponent<ObjectGrabbable>();
        if (grabbable != null)
        {
            isColliding = false;
            Debug.Log($"Stopped colliding with: {collision.gameObject.name}");
        }
    }
}
