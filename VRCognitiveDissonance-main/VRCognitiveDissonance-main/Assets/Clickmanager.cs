using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var interactable = hit.collider.GetComponent<QuadInteractor>();
                if (interactable != null)
                {
                    interactable.OnClicked();
                }
            }
        }
    }
}
