using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;


public static class CreateCSV
{
    private static string reportFolderName = "data";
    private static string reportFileName = "TabletAR_EXPData_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[4]
    {
        "Exercise Number",
        "Varient",
        "Time Taken",
        "TimeStamp when Leave"
    };


    public static void AppendToReport(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            sw.WriteLine(finalString);
            sw.Flush();
            sw.Close();
            Debug.Log(finalString);
        }

    }


    public static void CreateReport()
    {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            sw.WriteLine(finalString);
            sw.Flush();
            sw.Close();
        }
    }

    static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    static string GetDirectoryPath()
    {
        // For windows
        //return Application.dataPath + "/" + reportFolderName;
        // For android
        return Application.persistentDataPath + "/" + reportFolderName;
    }
    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName;
    }
}