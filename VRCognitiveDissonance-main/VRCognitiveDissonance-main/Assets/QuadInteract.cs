using UnityEngine;

public class QuadInteractor : MonoBehaviour
{
    public int quadID = 1;
    public SequentialAudioPlayer controller;

    public void OnClicked()
    {
        Debug.Log($"Quad {quadID} clicked!");

        if (controller == null)
        {
            Debug.LogWarning("Controller not set on QuadInteractor.");
            return;
        }

        if (quadID == 1)
            controller.OnText1Clicked();
        else if (quadID == 2)
            controller.OnText2Clicked();
    }
}
