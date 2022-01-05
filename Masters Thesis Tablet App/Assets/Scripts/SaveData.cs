using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveData : MonoBehaviour
{
    public Image ExperiementImage;
    // Start is called before the first frame update
    void Start()
    {
        string varientName = ExperiementImage.material.name;
        DateTime startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
