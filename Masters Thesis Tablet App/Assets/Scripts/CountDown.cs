using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float CurrentTime = 0f;
    float StartingTime = 3f;

    public Text CountDownText;
    public GameObject NextPanel;
    public GameObject ThisPanel;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartingTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        CountDownText.text = CurrentTime.ToString("0");
        if (CurrentTime <= 0)
        {
            NextPanel.SetActive(true);
            ThisPanel.SetActive(false);
        }
    }
}
