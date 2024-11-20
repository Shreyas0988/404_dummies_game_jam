using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairImage;


    void Start()
    {
    }

    void Update()
    {
        Screen.lockCursor = true;
    }
    void OnGUI(){
        float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height),crosshairImage);



    }
}