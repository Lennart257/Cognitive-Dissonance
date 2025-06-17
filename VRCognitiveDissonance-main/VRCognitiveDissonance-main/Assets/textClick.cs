using UnityEngine;

public class TextQuadClickable : MonoBehaviour
{
    public SequentialAudioPlayer controller; // Drag & assign the main script
    public int textID; // Set to 1 or 2 in the Inspector depending on which option this is

    void OnMouseDown()
    {
        Debug.Log($"Quad clicked! textID = {textID}");

        if (controller == null)
        {
            Debug.LogWarning("Controller not assigned on TextQuadClickable!");
            return;
        }

        if (textID == 1)
        {
            Debug.Log("Triggering Timeline 1...");
            controller.OnText1Clicked();
        }
        else if (textID == 2)
        {
            Debug.Log("Triggering Timeline 2...");
            controller.OnText2Clicked();
        }
        else
        {
            Debug.LogWarning("Invalid textID set! Must be 1 or 2.");
        }
    }
}
