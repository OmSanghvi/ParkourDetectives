using System.Collections;
using UnityEngine;

public class KeyCardInput : MonoBehaviour
{
    [SerializeField] private GameObject keyCard;
    [SerializeField] private GameObject garage;
    [SerializeField] private ObjectGrabbable objectGrabbable;
    private Coroutine timerCoroutine;
    public bool garageOpened;
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

    public void RotateKeyCard()
    {
        keyCard.transform.rotation = Quaternion.Euler(0, 0, 0); // Directly set the rotation
    }

    public void MoveKeyCard()
    {
        keyCard.transform.position = new Vector3(-6.43f, 3f, 24.21f);
        StartTimer();
    }

    private void MoveGarage()
    {
        garage.SetActive(false);
        garageOpened = true;
        soundManager.PlaySound(audioClipsRefsSO.clueCollected, mainCamera.transform.position);
        StopTimer();
    }

    private void StartTimer()
    {
        timerCoroutine = StartCoroutine(MoveGarageAfterDelay(2f));
    }

    private void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }

    private IEnumerator MoveGarageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MoveGarage();
    }

    private void Update()
    {
        if (keyCard.transform.localPosition.y < -10)
        {
            keyCard.transform.localPosition = new Vector3(-0.3f, 0.387f, -0.01f);
        }
    }
}
