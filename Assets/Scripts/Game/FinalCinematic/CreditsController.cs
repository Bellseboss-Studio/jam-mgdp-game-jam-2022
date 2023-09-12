using System;
using System.Collections;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    [SerializeField] private RectTransform credits;
    [SerializeField] private float speed;
    [SerializeField] private float timeToWait;
    private Coroutine corrutine;

    private void OnEnable()
    {
        corrutine = StartCoroutine(StartCredits());
        credits.anchoredPosition = Vector2.zero;
    }

    private IEnumerator StartCredits()
    {
        yield return new WaitForSeconds(timeToWait);
        while (credits.anchoredPosition.y >= 0 && credits.anchoredPosition.y < credits.rect.height)
        {
            credits.anchoredPosition += Vector2.up * speed * Time.deltaTime;
            yield return null;
        }
    }

    private void OnDisable()
    {
        StopCoroutine(corrutine);
    }
}