using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class File : Draggable
{
    private const float _MaxTimeBetweenClicks = 0.4f;

    [SerializeField]
    private Text _FileNameDisplay;

    [SerializeField]
    private string _FileName;

    [SerializeField]
    private FileType _FileType;

    [SerializeField]
    private Sprite _Image;

    [SerializeField]
    private string _Text;

    private float _LastClickTime = 0f;

    public string FileName => _FileName;

    public FileType FileType => _FileType;

    public Sprite Image => _Image;

    public string Text => _Text;
 
    void Start()
    {
        _FileNameDisplay.text = _FileName;
    }

    protected override void PointerDown(PointerEventData eventData)
    {
        float time = Time.time - _LastClickTime;
        if (time <= _MaxTimeBetweenClicks)
        {
            FileContentDisplayWindow displayWindow = FileContentDisplayWindow.DisplayWindow;
            displayWindow.DisplayFile(this);
        }
        _LastClickTime = Time.time;
    }
}
