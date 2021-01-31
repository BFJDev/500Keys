using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntivirusWindow : Draggable
{
    [SerializeField]
    private PentacleSlot _PentacleSlot;

    [SerializeField]
    private Button _CloseButton;

    public event System.Action Completed;

    private bool _HasCompleted = false;

    public GameManager gm;

    void Awake()
    {
        _CloseButton.onClick.AddListener( () => gameObject.SetActive(false));
    }

    void Update()
    {
        if (_HasCompleted == false && _PentacleSlot.PiecesFound == 5)
        {
            _HasCompleted = true;
            Completed?.Invoke();

            gm.EndGame(true);
        }
    }
}
