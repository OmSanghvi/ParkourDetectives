using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaPill : MonoBehaviour
{
    [SerializeField] private GameObject pill;
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
        pill.transform.position += new Vector3(2.269f, -1.178f,0f);
        pill.transform.localScale = new Vector3(4.5f,7.5f,4.5f);
        isOut = true;
        soundManager.PlaySound(audioClipsRefsSO.clueCollected, mainCamera.transform.position);

    }

    public void UnInteract()
    {
        pill.transform.position-= new Vector3(2.269f, -1.178f,0f);
        pill.transform.localScale = new Vector3(0.72f,1.2f,0.72f);
        isOut = false;
    }

    public void TogglePill()
    {
        if (isOut)
        {
            UnInteract();
        }
        else
        {
            Interact();
        }
    }
}
