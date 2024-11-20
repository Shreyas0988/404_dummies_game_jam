using UnityEngine;
using TMPro;

public class closet_door : MonoBehaviour
{
    public Animator drawer;
    private bool isOpen = false;

    void Start()
    {
        drawer = GetComponent<Animator>();
        drawer.SetBool("isOpen", isOpen); // Start in idle state
    }
    
    void OnMouseDown(){
        ToggleDrawer();
        Debug.Log("closet door opening");
    }

    void ToggleDrawer()
    {
        isOpen = !isOpen; // Toggle the open state
        drawer.SetBool("isOpen", isOpen); // Update animator
    }
}
