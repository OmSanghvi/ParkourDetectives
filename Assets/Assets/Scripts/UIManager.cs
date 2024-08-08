using StarterAssets;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiPanel;  // Reference to your UI panel// Reference to your first person controller script

    private bool isUIActive;

    void Update()
    {
        if (isUIActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ShowUI()
    {
        uiPanel.SetActive(true);
        isUIActive = true;
    }

    public void HideUI()
    {
        uiPanel.SetActive(false);
        isUIActive = false;
    }
}