using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioClipsRefsSO audioClipsRefsSO;
    [SerializeField] private SoundManager soundManager;
    private GameObject mainCamera;
    public float openAngle = 90f; // Angle to open the door (usually 90 degrees for a quarter turn)// Angle to close the door (0 degrees, closed)

    public bool isOpen;
    private Quaternion initialRotation;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    public void ToggleDoor()
    {
            if (isOpen)
                CloseDoor();
            else
                OpenDoor();
    }

    private void OpenDoor()
    {
        initialRotation = transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, openAngle, 0); // Calculate the target rotation
        transform.rotation = targetRotation; // Set the door's rotation to the target rotation
        transform.position += new Vector3(1.3f, 0f, 1.17f);
        isOpen = true;
        soundManager.PlaySound(audioClipsRefsSO.doorOpen, mainCamera.transform.position);
    }

    private void CloseDoor()
    {
        transform.rotation = initialRotation;
        transform.position -= new Vector3(1.3f, 0f, 1.17f);// Set the door's rotation back to its initial rotation
        isOpen = false;
        soundManager.PlaySound(audioClipsRefsSO.doorClose, mainCamera.transform.position);
    }

    public void setDoorBack()
    {
        if (isOpen)
        {
            transform.rotation = initialRotation;
            transform.position -= new Vector3(1.3f, 0f, 1.17f);// Set the door's rotation back to its initial rotation
            isOpen = false;
        }
    }
}