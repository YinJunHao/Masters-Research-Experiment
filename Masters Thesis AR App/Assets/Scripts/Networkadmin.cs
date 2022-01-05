using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Networkadmin : MonoBehaviour
{
    public InputField networkfield;
    public static string networkID;
    public void SceneChange()
    {
        Debug.Log(networkfield.text);
        networkID = networkfield.text.ToString();
        SceneManager.LoadScene("Main Scene");
    }
}
