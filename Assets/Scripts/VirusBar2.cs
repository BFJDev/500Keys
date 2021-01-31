using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusBar2 : MonoBehaviour
{

    public Slider slider;
    public Text virusText;
    float Timer;
    public int DelayAmount = 1; // Second count

    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 90;
        slider.minValue = 0;
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            slider.value += 1;
            virusText.text = "Virus Upload: " + Mathf.FloorToInt(slider.value / slider.maxValue * 100) + "%";

            if(slider.value >= slider.maxValue)
            {
                GM.EndGame(false);
            }
        }
    }
}
