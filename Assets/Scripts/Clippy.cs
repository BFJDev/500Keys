using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clippy : MonoBehaviour
{
    public static Clippy Instance {get; private set;}

    [SerializeField]
    private List<string> _PieceFindReactions;

    [SerializeField]
    private List<string> _WrongFileOpenedReactions;

    [SerializeField]
    private List<string> _NormalTaunts;

    [SerializeField]
    private RectTransform _RectTransform;

    [SerializeField]
    private Animator _Animator;

    [SerializeField]
    private GameObject _SpeechBubble;

    [SerializeField]
    private Text _TextBox;

    private float _TimeLastSmackTalk;

    private float _TimeBetweenSmackTalk = 15;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        FileContentDisplayWindow.DisplayWindow.FileOpened += RespondToFileOpened;
    }

    void Update()
    {
        if (Time.time - _TimeLastSmackTalk > _TimeBetweenSmackTalk)
        {
            SmackTalk();
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

    public void SpeakCustomTrigger(string triggerName, string dialog, float duration = -1)
    {
        _Animator.SetTrigger(triggerName);
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

    private void RespondToFileOpened(File file)
    {
        PentaclePiece piece = file.gameObject.GetComponent<PentaclePiece>();
        if(piece != null)
        {
            SpeakCustomTrigger("PlayInspect", _PieceFindReactions[0], 5);
            _PieceFindReactions.RemoveAt(0);
        }
        else
        {
            int randomValue = Random.Range(0,10);
            if(randomValue < 3)
            {
                int randomReaction = Random.Range(0,_WrongFileOpenedReactions.Count);
                SpeakCustomTrigger("PlayFileOpen", _WrongFileOpenedReactions[randomReaction], 5);
            }
        }
    }

    private void SmackTalk()
    {
        _TimeLastSmackTalk = Time.time;
        if(_NormalTaunts.Count > 0)
        {
            int randomReaction = Random.Range(0, _NormalTaunts.Count);
            SpeakCustomTrigger("PlayTaunt", _NormalTaunts[randomReaction]);
            _NormalTaunts.RemoveAt(randomReaction);
        }
    }
}
