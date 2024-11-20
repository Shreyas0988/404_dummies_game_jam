using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weighing_scale_code : MonoBehaviour
{
    // Assign these GameObjects in the Inspector
    public GameObject book1; 
    public GameObject book2; 
    public GameObject flowerPot;
    public GameObject tableLamp;
    public GameObject pileOfClothes;

    // Corresponding weights
    private Dictionary<GameObject, int> objectWeights = new Dictionary<GameObject, int>();

    // TextMeshPro element to display the weight
    public TextMeshProUGUI weightDisplay;

    // Variable to store the total weight
    private int totalWeight = 0;
    public GameObject last;

    private void Start()
    {
        // Initialize the dictionary with objects and their weights
        objectWeights.Add(book1, 500);
        objectWeights.Add(book2, 300);
        objectWeights.Add(flowerPot, 900);
        objectWeights.Add(tableLamp, 1100);
        objectWeights.Add(pileOfClothes, 250);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is in the dictionary
        if (objectWeights.ContainsKey(collision.gameObject))
        {
            totalWeight += objectWeights[collision.gameObject];
            UpdateWeightDisplay();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Remove weight when the object stops colliding
        if (objectWeights.ContainsKey(collision.gameObject))
        {
            totalWeight -= objectWeights[collision.gameObject];
            UpdateWeightDisplay();
        }
    }

    private void UpdateWeightDisplay()
    {
        // Update the TextMeshPro text with the current total weight
        weightDisplay.text = ""+totalWeight;
        if (totalWeight == 1450){
            //last.setActive = true;
        }
    }
}
