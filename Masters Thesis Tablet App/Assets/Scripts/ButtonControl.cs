using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonControl : MonoBehaviour
{
   
    public void OpenPage(GameObject NextPage)
    {
        NextPage.SetActive(true);

    }
    public void ClosePage(GameObject CurrentPage)
    {
        CurrentPage.SetActive(false);
    }

    public void exitApp()
    {
        Application.Quit();
    }

    public void logData(Image ExperimentImage)
    {
        string number = ExperimentImage.transform.parent.transform.parent.name;
        string variant = ExperimentImage.material.name;
        PigpenPopulate pigpenpopulate = ExperimentImage.transform.parent.gameObject.GetComponent<PigpenPopulate>();
        float startTime = pigpenpopulate.StartTime;
        float endTime = Time.time - startTime;
        Debug.Log(number);
        Debug.Log(variant);
        Debug.Log(endTime);
        string timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        CreateCSV.AppendToReport(new string[4] {
            number,
            variant,
            endTime.ToString(),
            timestamp
        }) ;
    }
    public void logRest(Text ExperimentText)
    {
        string number = ExperimentText.transform.parent.name;
        string variant = " ";
        string endTime = " ";
        string timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        CreateCSV.AppendToReport(new string[4] {
            number,
            variant,
            endTime.ToString(),
            timestamp
        });
    }
}
