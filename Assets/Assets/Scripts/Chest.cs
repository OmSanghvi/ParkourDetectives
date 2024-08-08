using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject chestLid;
    private Quaternion initialRotation;
    public bool isRotated;

    private void OpenChestLid()
    {
        initialRotation = chestLid.transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 0, -90); // Calculate the target rotation
        chestLid.transform.rotation = targetRotation;
        isRotated = true;
    }

    public void CloseChestLid()
    {
        chestLid.transform.rotation = initialRotation;
        isRotated = false;
    }

    public void ToggleChestLid()
    {
        if (isRotated)
        {
            CloseChestLid();
        }
        else
        {
            OpenChestLid();
        }
    }
}
