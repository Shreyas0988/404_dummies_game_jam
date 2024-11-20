using UnityEngine;

public class LaserCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "LaserBeam")
        {
            Debug.Log("ok");
        }
    }
}
