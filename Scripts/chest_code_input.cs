using TMPro;
using UnityEngine;

public class InputFieldActivator : MonoBehaviour
{
    public TMP_InputField tmpInputField;

    public void OnMouseDown()
    {
        Debug.Log("chest clicked");
        // Check if the TMP Input Field is assigned
        if (tmpInputField != null)
        {
            // Activate and focus on the TMP input field
            tmpInputField.ActivateInputField();
        }
    }
}
