using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportCarFrontHood : MonoBehaviour
{
    public float openAngle = -18f;
    public GameObject frontHood;

    public bool isOpen;
    private Quaternion initialRotation;

    public void ToggleDoor()
    {
        if (isOpen)
            CloseDoor();
        else
            OpenDoor();
    }

    private void OpenDoor()
    {
        initialRotation = frontHood.transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(openAngle, 0, 0); // Calculate the target rotation
        frontHood.transform.rotation = targetRotation; // Set the door's rotation to the target rotation
        isOpen = true;
    }

    private void CloseDoor()
    {
        frontHood.transform.rotation = initialRotation;
        isOpen = false;
    }

    public bool GetIsOpen()
    {
        return isOpen;
    }
}
