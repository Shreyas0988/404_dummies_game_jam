using UnityEngine;

public class Button : MonoBehaviour
{
    public MorseCodeLight morseCodeLight;

    void OnMouseDown()
    {
        Debug.Log("Button clicked!"); // Check if button click is detected
        morseCodeLight.StartMorseCode();
    }
}
