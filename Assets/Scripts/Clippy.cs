using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clippy : MonoBehaviour
{
    public static Clippy Instance {get; private set;}

    [SerializeField]
    private RectTransform _RectTransform;

    [SerializeField]
    private Animator _Animator;

    [SerializeField]
    private GameObject _SpeechBubble;

    [SerializeField]
    private Text _TextBox;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void MoveTo(Vector2 newLocation, float duration)
    {
        StartCoroutine(MoveToLocation(newLocation, duration));
    }

    public void Speak(string dialog, float duration = -1)
    {
        _Animator.SetTrigger("PlayTalking");
        _TextBox.gameObject.SetActive(true);
        _TextBox.text = dialog;
        if (duration > 0)
        {
            StartCoroutine(WaitToCloseTextBox(duration));
        }
    }

    private IEnumerator WaitToCloseTextBox(float duration)
    {
        float timeElapsed = 0;

        while(timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        _TextBox.gameObject.SetActive(false);
    }

    private IEnumerator MoveToLocation(Vector2 newLocation, float duration)
    {
        Vector2 startingLocation = _RectTransform.anchoredPosition;

        float timeElapsed = 0;

        while(timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            _RectTransform.anchoredPosition = Vector2.Lerp(startingLocation, newLocation, timeElapsed/duration);

            yield return null;
        }

        _RectTransform.anchoredPosition = newLocation;
    }
}
