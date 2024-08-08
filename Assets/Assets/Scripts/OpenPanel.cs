using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject choosingCanvas;
    public GameObject popUpPanel;

    public void Start()
    {
        choosingCanvas.SetActive(false);
        popUpPanel.SetActive(false);
    }

    public void ButtonOpenPanel()
    {
            bool isActiveChoosingCanvas = choosingCanvas.activeSelf;
            choosingCanvas.SetActive(!isActiveChoosingCanvas);
            bool isActivePopUpPanel = popUpPanel.activeSelf;
            popUpPanel.SetActive(!isActivePopUpPanel);
    }
}
