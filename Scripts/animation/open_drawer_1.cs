using UnityEngine;
using TMPro;

public class open_drawer_1 : MonoBehaviour
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
        Debug.Log("drawer opening");
    }

    void ToggleDrawer()
    {
        isOpen = !isOpen; // Toggle the open state
        drawer.SetBool("isOpen", isOpen); // Update animator
    }
}
