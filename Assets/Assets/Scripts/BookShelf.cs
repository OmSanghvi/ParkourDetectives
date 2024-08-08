using UnityEngine;
using System.Collections;

public class BookShelf : MonoBehaviour
{
    [SerializeField] private GameObject bigPage;
    [SerializeField] private GameObject smallPage;
    private Coroutine timerCoroutine;
    private bool isOut;
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
    

    private void Start()
    {
        bigPage.SetActive(false);
    }

    public void ShowBigPage()
    {
        Debug.Log("Showing big page...");
        bigPage.SetActive(true);
        smallPage.SetActive(false);
        isOut = true;
        soundManager.PlaySound(audioClipsRefsSO.clueCollected, mainCamera.transform.position);
        StartTimer();
    }

    public void ToggleBookShelf()
    {
        if (isOut)
        {
            StopShowBigPage();
        }
        else
        {
            ShowBigPage();
        }
    }

    public void StopShowBigPage()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
        bigPage.SetActive(false);
        smallPage.SetActive(true);
        isOut = false;
        StopTimer();
    }
    
    private void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            Debug.Log("Timer stopped.");
        }
    }

    private void StartTimer()
    {
        Debug.Log("Starting timer...");
        timerCoroutine = StartCoroutine(HideBigPageAfterDelay(30f)); // Start timer for 5 seconds (for testing purposes)
    }

    private IEnumerator HideBigPageAfterDelay(float delay)
    {
        Debug.Log("Waiting for " + delay + " seconds...");
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        StopShowBigPage(); // Hide bigPage after the delay
    }
}