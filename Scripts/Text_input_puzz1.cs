using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class Text_input_puzz1 : MonoBehaviour
{
    private string input;
    public TMP_InputField inputField; // Specify the correct type
    public Animator chestAnimator;

    void Start()
    {
        // Clear the input field at the start
        if (inputField != null)
        {
            inputField.text = ""; 
        }
    }

    void Update()
    {
        // Update logic can go here
    }

    public void ReadStringInput(string s)
    {
        input = s;
        
        if (input == "fear")
        {
            chestAnimator.SetBool("isCorrect", true);
            Debug.Log("Finished!");
        }

        // Clear the input text after processing
        input = ""; // Clear the stored input
        if (inputField != null)
        {
            inputField.text = ""; // Clear the TMP_InputField
        }
    }
}
