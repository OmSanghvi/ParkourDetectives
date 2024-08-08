using System.Collections;
using UnityEngine;

public class DiningTableDrawers : MonoBehaviour
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

    private void OpenDrawer()
    {
        letter.transform.position += new Vector3(0f, 0.693f, -8f);
        letter.transform.localScale = new Vector3(3.1f, 3.1f, 3.1f);
        isOut = true;
        soundManager.PlaySound(audioClipsRefsSO.clueCollected, mainCamera.transform.position);
        StartTimer();
    }

    public void ToggleDrawers()
    {
        if (isOut)
        {
            PutBack();
        }
        else
        {
            OpenDrawer();
        }
    }

    public void PutBack()
    {
        letter.transform.position -= new Vector3(0f, 0.693f, -8f);
        letter.transform.localScale = new Vector3(0.63f, 0.63f, 0.63f);
        isOut = false;
        StopTimer(); // Call the method to stop the timer coroutine
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