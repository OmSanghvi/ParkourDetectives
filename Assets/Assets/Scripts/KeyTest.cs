using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTest : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private Chest chest;
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
    private Quaternion initialRotation;
    private Coroutine timerCoroutine;
    public bool keyMovedAndRotated;

    private void KeyOpenChestMove()
    {
        key.transform.position = new Vector3(23.033f, 0.7f, -15.79f);
        StopTimer();
        StartTimerForRotation();
    }
    public void KeyOpenChestRotateAtStart()
    {
        ResetKeyRotation();
        initialRotation = key.transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 90, -90);
        key.transform.rotation = targetRotation;
        KeyOpenChestMove();
    }

    private void RotateKeyAtEnd()
    {
        initialRotation = key.transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 0, -90);
        key.transform.rotation = targetRotation;
        StopTimer();
        keyMovedAndRotated = true;
        StartTimerOpenChest();

    }

    private void StartTimerForRotation()
    {
        timerCoroutine = StartCoroutine(RotateKey(1f));
    }

    private void StartTimerOpenChest()
    {
        timerCoroutine = StartCoroutine(OpenChest(1.5f));
    }
    

    private void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }
    
    private IEnumerator RotateKey(float delay)
    {
        yield return new WaitForSeconds(delay);
        RotateKeyAtEnd();
    }

    private IEnumerator OpenChest(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!chest.isRotated)
        { 
            chest.ToggleChestLid(); 
            soundManager.PlaySound(audioClipsRefsSO.clueCollected, mainCamera.transform.position);
        } 
    }
    
    public void ResetKeyRotation()
    {
        key.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void ResetKeyPosition()
    {
        key.transform.position = new Vector3(11.325f, 1.228f, -18.13f);
    }

}
