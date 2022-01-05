using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChange : MonoBehaviour
{
    public InputField networkfield;
    public static string networkID;
    public void showScene()
    {
        Debug.Log("tets");
        Debug.Log(networkfield.text);
        networkID = networkfield.text.ToString();
        SceneManager.LoadScene("Masters Thesis Tablet");
        
    }
}
