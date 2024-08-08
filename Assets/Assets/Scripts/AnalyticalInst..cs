using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticalInst : MonoBehaviour
{
    [SerializeField] private GameObject textMesh;
    [SerializeField] private GameObject flask;

    private Coroutine timerCoroutine;
    public bool textIsShown;

    private void Start()
    {
        textMesh.SetActive(false);
    }

    public void Scan()
    {
        flask.transform.position = new Vector3(19.156f, 2.045f, -8.005f);
        flask.transform.rotation = Quaternion.Euler(0, 0, 0);
        StartTimerShowText();
    }

    private void ShowText()
    {
        textMesh.SetActive(true);
        textIsShown = true;
        StopTimer();
        StartTimerHideText();
    }

    public void HideText()
    {
        textMesh.SetActive(false);
        textIsShown = false;
        StopTimer();
    }

    private void StartTimerShowText()
    {
        timerCoroutine = StartCoroutine(ShowTextAfterDelay(1f));
    }

    private void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }

    private IEnumerator ShowTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowText();
    }
    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HideText();
    }
    private void StartTimerHideText()
    {
        timerCoroutine = StartCoroutine(HideTextAfterDelay(5f));
    }
}
