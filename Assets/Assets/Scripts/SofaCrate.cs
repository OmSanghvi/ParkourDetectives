using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaCrate : MonoBehaviour
{
    public GameObject crate;
    [SerializeField] private BoxController boxController;
    public bool isOut;
    [SerializeField] private AudioClipsRefsSO audioClipsRefsSO;
    [SerializeField] private SoundManager soundManager;
    private GameObject mainCamera;
    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    private void Interact()
    {
        crate.transform.position += new Vector3(4f, -1.764f,0f);
        crate.transform.localScale = new Vector3(1.13f,1.13f,1.13f);
        isOut = true;
        soundManager.PlaySound(audioClipsRefsSO.clueCollected, mainCamera.transform.position);
    }
    
    public void unInteract()
    {
        if (boxController.isOpen)
        {
            boxController.CloseBox();
        }
        crate.transform.position -= new Vector3(4f, -1.764f,0f);
        crate.transform.localScale = new Vector3(0.52f,0.52f,0.52f);
        isOut = false;

    }

    public void ToggleSofa()
    {
        if (isOut)
        {
            unInteract();
        }
        else
        {
            Interact();
        }
    }

}
