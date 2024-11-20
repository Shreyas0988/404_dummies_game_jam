using UnityEngine;
using TMPro;

public class open_table_door : MonoBehaviour
{
    public Animator drawer;
    private bool isOpen = false;

    void Start()
    {
        drawer = GetComponent<Animator>();
        drawer.SetBool("isOpen", isOpen); // Start in idle state
    }
    
    void OnMouseDown(){
        Debug.Log("door opening");
        ToggleDrawer();
    }

    void ToggleDrawer()
    {
        isOpen = !isOpen; // Toggle the open state
        drawer.SetBool("isOpen", isOpen); // Update animator
    }
}
