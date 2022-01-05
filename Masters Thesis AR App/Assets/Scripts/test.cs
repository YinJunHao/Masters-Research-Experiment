using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class test : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject button;
    public GameObject CurrentPage;
    public GameObject nextPage;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("VirtualButton");
        button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        CurrentPage.SetActive(false);
        nextPage.SetActive(true);
        Debug.Log(button.name);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        Debug.Log("Releassed");

    }
}
