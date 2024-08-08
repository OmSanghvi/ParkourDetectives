using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainButtonCode : MonoBehaviour
{
    public GameObject incorrectText;
    public GameObject tryAgainButton;
    public GameObject sumbitButton;

    public void tryAgainButtonCodeInput()
    {
        incorrectText.SetActive(false);
        tryAgainButton.SetActive(false);
        sumbitButton.SetActive(true);
    }
}
