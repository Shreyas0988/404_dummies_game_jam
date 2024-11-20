using UnityEngine;
using System.Collections;

public class MorseCodeLight : MonoBehaviour
{
    public Light lightSource;
    [SerializeField] public Material ceilingLightMaterial; // Reference to the ceiling light's material
    public float dotDuration = 3f; // Duration for a dot in seconds
    public float dashDuration = 6f; // Duration for a dash in seconds
    public float gapDuration = 1f; // Gap between signals in seconds
    public float letterGapDuration = 10f; // Gap between letters in seconds

    // Morse code sequence: 'dot', 'dash', 'gap' (false means off)
    bool[][] morseCodeSequence = {
        new bool[] {true, true, false, true}, // F (..-.)
        new bool[] {true},                    // E (.)
        new bool[] {true, false},             // A (.-)
        new bool[] {true, false, true}        // R (.-.)
    };

    private Coroutine morseCoroutine;

    private void Start()
    {
        // Initialize the light and material state
        if (lightSource != null)
        {
            lightSource.enabled = false; // Turn off the light initially
        }
        
        if (ceilingLightMaterial != null)
        {
            ceilingLightMaterial.DisableKeyword("_EMISSION");
        }
    }

    public void StartMorseCode()
    {
        if (morseCoroutine == null)
        {
            morseCoroutine = StartCoroutine(FlickerLight());
        }
    }

    private IEnumerator FlickerLight()
    {
        foreach (bool[] letter in morseCodeSequence)
        {
            foreach (bool signal in letter)
            {
                if (signal)
                {
                    lightSource.enabled = true;
                    SetCeilingLightEmission(true); // Enable emission
                    yield return new WaitForSeconds(dotDuration);
                }
                else
                {
                    lightSource.enabled = true;
                    SetCeilingLightEmission(true); // Enable emission
                    yield return new WaitForSeconds(dashDuration);
                }
                lightSource.enabled = false;
                SetCeilingLightEmission(false); // Disable emission
                yield return new WaitForSeconds(gapDuration);
            }
            yield return new WaitForSeconds(letterGapDuration);
        }

        // Turn off the light and reset coroutine reference
        lightSource.enabled = false;
        SetCeilingLightEmission(false); // Ensure emission is disabled
        morseCoroutine = null;
    }

    private void SetCeilingLightEmission(bool isEmitting)
    {
       
        if (ceilingLightMaterial != null)
        {
            if (isEmitting)
            {
                
                ceilingLightMaterial.EnableKeyword("_EMISSION");
            }
            else
            {
                ceilingLightMaterial.DisableKeyword("_EMISSION");
            }
        }
    }
}
