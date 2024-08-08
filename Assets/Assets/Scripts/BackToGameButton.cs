using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToGameButton : MonoBehaviour
{
    public GameObject codePanel;
    public BoxController box;
    public GameObject tryAgainButton;
    public GameObject submitButton;
    public GameObject incorrectText;
    public GameObject correctText;

    public void goBack()
    {
        codePanel.SetActive(false);
        tryAgainButton.SetActive(false);
        submitButton.SetActive(true);
        incorrectText.SetActive(false);
        correctText.SetActive(false);
        if (box.isOpen)
        {
            box.CloseBox();
        }
    }
}
