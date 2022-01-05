using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class CountDown : MonoBehaviour, IVirtualButtonEventHandler
{
    float CurrentTime = 0f;
    float StartingTime = 3f;
    public TextMesh countDownText;
    public GameObject pigPen;
    public GameObject nextButton;
    public GameObject backButton;
    public Renderer nextButtonPlane;
    public Renderer backButtonPlane;
    public TextMesh nextButtonText;
    public TextMesh backButtonText;
    public Material greenButton;
    public Material greyButton;
    public Material transparent;
    public Material transparent1;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartingTime;
        nextButtonText.text = "";
        backButtonText.text = "";
        nextButtonPlane.material = transparent;
        backButtonPlane.material = transparent1;
        backButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        countDownText.text = CurrentTime.ToString("0");
        if (CurrentTime <= 0)
        {
            countDownText.gameObject.SetActive(false);
            pigPen.SetActive(true);
            //nextButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
            backButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
            nextButtonText.text = "Done";
            backButtonText.text = "Cancel";
            nextButtonPlane.material = greenButton;
            backButtonPlane.material = greyButton;
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    }
}
