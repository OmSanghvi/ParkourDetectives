using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{ 
    public GameObject letter;
    private Coroutine timerCoroutine;
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

    private void OpenWardrobe()
    {
        letter.transform.position += new Vector3(3.83f, 0.15f, -1.52f);
        letter.transform.localScale = new Vector3(3.1f,3.1f,3.1f);
        soundManager.PlaySound(audioClipsRefsSO.clueCollected, mainCamera.transform.position);
        isOut = true;
        StartTimer();
        
    }

    public void ToggleWardrobe()
    {
        if (isOut)
        {
            PutBack();
        }
        else
        {
            OpenWardrobe();
        }
    }

    public void PutBack()
    {
        letter.transform.position -= new Vector3(3.83f, 0.15f, -1.52f);
        letter.transform.localScale = new Vector3(1f,1f,1f);
        isOut = false;
        StopTimer();
    }
    private void StartTimer()
    {
        timerCoroutine = StartCoroutine(HideLetterAfterDelay(30f));
    }
    private void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }

    private IEnumerator HideLetterAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PutBack();
    }
}
