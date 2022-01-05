using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeScene : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject button;
    public GameObject CurrentPage;
    public GameObject nextPage;
    // Start is called before the first frame update
    void Start()
    {
        string buttonName = "VirtualButton" + button.transform.parent.name;
        button = GameObject.Find(buttonName);
        button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        Debug.Log(button.transform.parent.name);
        
    }
    void Update()
    {
        string buttonName = "VirtualButton" + button.transform.parent.name;
        button = GameObject.Find(buttonName);
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
