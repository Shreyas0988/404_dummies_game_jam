using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotationAngle = 30f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
      
            transform.Rotate(0, rotationAngle, 0, Space.Self);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
         
            transform.Rotate(0, -rotationAngle, 0, Space.Self);
        }
    }
}
