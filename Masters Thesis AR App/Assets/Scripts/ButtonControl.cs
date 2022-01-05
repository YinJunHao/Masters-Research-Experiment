using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;


public class ButtonControl : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject nextButton;
    public Renderer nextButtonPlane;
    public GameObject backButton;
    public Renderer backButtonPlane;
    public GameObject parent;
    public TextMesh nextButtonText;
    public TextMesh backButtonText;
    private string currentPageName = "Home";
    private string nextPageName = "Disclaimer";
    private string backPageName = "";
    private Transform currentPage;
    private Transform nextPage;
    private Transform backPage;
    private string[] exercisePageBefore = {"Exercise 1 Before", "Exercise 2 Before", "Exercise 3 Before", "Exercise 4 Before", "Exercise 5 Before", "Exercise 6 Before" };
    private string[] exercisePage = {"Exercise 1", "Exercise 2", "Exercise 3", "Exercise 4", "Exercise 5", "Exercise 6"};
    private string[] page = {"Disclaimer", "Pigpen Cipher", "Procedure", "Part 1", "Part 2"};
    public Material greenButton;
    public Material greyButton;
    public Material blueButton;
    public Material transparent;
    private float timeout = 1f;
    private float timestamp;
    private float endTime;
    // Start is called before the first frame update
    void Start()
    {
        
        nextButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        backButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        currentPage = parent.transform.Find(currentPageName);
        nextPage = parent.transform.Find(nextPageName);
        backPage = parent.transform.Find(backPageName);
        backButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
        timestamp = Time.time;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log(vb.name + "Pressed");
        if (vb.name == "NextButton" && Time.time>=timestamp)
        {
            if (exercisePage.Contains(currentPageName))
            {
                Debug.Log("Logging " + currentPageName);
                PigpenPopulate pigpenpopulate = currentPage.gameObject.transform.Find("Quad (1)").GetComponent<PigpenPopulate>();
                float startTime = pigpenpopulate.StartTime;
                Debug.Log("the start time is "+ startTime.ToString());
                float endTime = Time.time - startTime;
                string timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                string variant = pigpenpopulate.ExerciseImage.GetComponent<MeshRenderer>().material.name;
                CreateCSV.AppendToReport(new string[4] {
                    currentPageName,
                    variant,
                    endTime.ToString(),
                    timestamp
                });
            }
            else
            {
                Debug.Log("Logging " + currentPageName);
                string timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                CreateCSV.AppendToReport(new string[4] {
                    currentPageName,
                    " ",
                    " ",
                    timestamp
                });
            }
            currentPage.gameObject.SetActive(false);
            nextPage.gameObject.SetActive(true);
            if (exercisePageBefore.Contains(nextPageName))
            {
                Debug.Log(nextPageName);
                nextButtonText.text = "Start";
                nextButtonPlane.material = blueButton;
                backButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
                backButtonPlane.material = transparent;
                backButtonText.text = "";
            }
            else if (exercisePage.Contains(nextPageName))
            {
                Debug.Log("Performing " + nextPageName);
            }
            else
            {
                backButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
                backButtonPlane.material = transparent;
                backButtonText.text = "";
                Debug.Log(nextPageName);
                nextButtonPlane.material = blueButton;
                nextButtonText.text = "Continue";
            }
            if (nextPageName == "End")
            {
                nextButtonText.text = "Close";
                nextButtonPlane.material = greyButton;
                backButtonPlane.material = transparent;
                backButtonText.text = "";
                backButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
            }
            if (currentPageName == "End")
            {
                Application.Quit();
            }
            if (page.Contains(nextPageName))
            {
                backButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
                backButtonPlane.material = greyButton;
                backButtonText.text = "Back";
            }
            backPageName = getNextPageName(backPageName);
            currentPageName = getNextPageName(currentPageName);
            nextPageName = getNextPageName(nextPageName);
            currentPage = parent.transform.Find(currentPageName);
            nextPage = parent.transform.Find(nextPageName);
            backPage = parent.transform.Find(backPageName);
        }
        if (vb.name == "BackButton" && Time.time >= timestamp)
        {
            if (exercisePage.Contains(currentPageName))
            {
                PigpenPopulate pigpenpopulate = currentPage.gameObject.transform.Find("Quad (1)").GetComponent<PigpenPopulate>();
                float startTime = pigpenpopulate.StartTime;
                float endTime = Time.time - startTime;
                string timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                string variant = pigpenpopulate.ExerciseImage.GetComponent<MeshRenderer>().material.name;
                CreateCSV.AppendToReport(new string[4] {
                    currentPageName,
                    variant + " failed",
                    endTime.ToString(),
                    timestamp
                });
            }
            else
            {
                string timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                CreateCSV.AppendToReport(new string[4] {
                    currentPageName,
                    " ",
                    " ",
                    timestamp
                });
            }
            backPage.gameObject.SetActive(true);
            currentPage.gameObject.SetActive(false);
            if (exercisePageBefore.Contains(backPageName))
            {
                nextButtonText.text = "Start";
                nextButtonPlane.material = blueButton;
                backButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
                backButtonPlane.material = transparent;
                backButtonText.text = "";
            }
            else if (exercisePageBefore.Contains(backPageName))
            {
                Debug.Log(nextPageName);
            }
            else
            {
                backButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
                backButtonPlane.material = transparent;
                backButtonText.text = "";
                Debug.Log(nextPageName);
                nextButtonPlane.material = blueButton;
                nextButtonText.text = "Continue";
            }
            if (page.Contains(backPageName))
            {
                backButton.GetComponent<VirtualButtonBehaviour>().enabled = true;
                backButtonPlane.material = greyButton;
                backButtonText.text = "Back";
            }
            currentPageName = getBackPageName(currentPageName);
            nextPageName = getBackPageName(nextPageName);
            backPageName = getBackPageName(backPageName);
            currentPage = parent.transform.Find(currentPageName);
            nextPage = parent.transform.Find(nextPageName);
            backPage = parent.transform.Find(backPageName);
        }
        
        timestamp = Time.time + timeout;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log(vb.name + " Released");
    }

    private string getNextPageName(string currentName)
    {
        string nextName="";
        switch(currentName)
        {
            case "":
                nextName = "Home";
                break;
            case "Home":
                nextName = "Disclaimer";
                break;
            case "Disclaimer":
                nextName = "Pigpen Cipher";
                break;
            case "Pigpen Cipher":
                nextName = "Procedure";
                break;
            case "Procedure":
                nextName = "Part 1";
                break;
            case "Part 1":
                nextName = "Exercise 1 Before";
                break;
            case "Exercise 1 Before":
                nextName = "Exercise 1";
                break;
            case "Exercise 1":
                nextName = "Exercise 2 Before";
                break;
            case "Exercise 2 Before":
                nextName = "Exercise 2";
                break;
            case "Exercise 2":
                nextName = "Exercise 3 Before";
                break;
            case "Exercise 3 Before":
                nextName = "Exercise 3";
                break;       
            case "Exercise 3":
                nextName = "Rest";
                break;
            case "Rest":
                nextName = "Part 2";
                break;
            case "Part 2":
                nextName = "Exercise 4 Before";
                break;
            case "Exercise 4 Before":
                nextName = "Exercise 4";
                break;
            case "Exercise 4":
                nextName = "Exercise 5 Before";
                break;
            case "Exercise 5 Before":
                nextName = "Exercise 5";
                break;
            case "Exercise 5":
                nextName = "Exercise 6 Before";
                break;
            case "Exercise 6 Before":
                nextName = "Exercise 6";
                break;
            case "Exercise 6":
                nextName = "End";
                break;
        }
        return nextName;
    }

    private string getBackPageName(string Name)
    {
        string nextBackName = "";
        switch (Name)
        {
            case "Home":
                nextBackName = "";
                break;
            case "Disclaimer":
                nextBackName = "Home";
                break;
            case "Pigpen Cipher":
                nextBackName = "Disclaimer";
                break;
            case "Procedure":
                nextBackName = "Pigpen Cipher";
                break;
            case "Part 1":
                nextBackName = "Procedure";
                break;
            case "Exercise 1 Before":
                nextBackName = "Part 1";
                break;
            case "Exercise 1":
                nextBackName = "Exercise 1 Before";
                break;
            case "Exercise 2 Before":
                nextBackName = "Exercise 1";
                break;
            case "Exercise 2":
                nextBackName = "Exercise 2 Before";
                break;
            case "Exercise 3 Before":
                nextBackName = "Exercise 2";
                break;
            case "Exercise 3":
                nextBackName = "Exercise 3 Before";
                break;
            case "Rest":
                nextBackName = "Exercise 3";
                break;
            case "Part 2":
                nextBackName = "Rest";
                break;
            case "Exercise 4 Before":
                nextBackName = "Part 2";
                break;
            case "Exercise 4":
                nextBackName = "Exercise 4 Before";
                break;
            case "Exercise 5 Before":
                nextBackName = "Exercise 4";
                break;
            case "Exercise 5":
                nextBackName = "Exercise 5 Before";
                break;
            case "Exercise 6 Before":
                nextBackName = "Exercise 5";
                break;
            case "Exercise 6":
                nextBackName = "Exercise 6 Before";
                break;

        }
        return nextBackName;
    }
}
