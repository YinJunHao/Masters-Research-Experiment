using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PigpenPopulate : MonoBehaviour
{

    public GameObject ExerciseImage;
    private Object[] materials;
    int index;
    public float StartTime;
    // Start is called before the first frame update
    void Start()
    {
        calculateTime();
        Debug.Log(StartTime);
        materials = Resources.LoadAll("", typeof(Material));
        List<string> CheckResources = ResourceManager.GetResourcesList();
        bool assigned = true;
        while (assigned)
        {
            index = Random.Range(0, materials.Length);
            Material pigpen = (Material)materials[index];
            if (pigpen.name.Contains("Varient")) {
                bool check = CheckResources.Contains(pigpen.name);
                if (check == false)
                {
                    ExerciseImage.GetComponent<MeshRenderer>().material = pigpen;
                    ResourceManager.AppendToList(pigpen.name);
                    assigned = false;
                    Debug.Log(pigpen.name);
                }
            }
        }

    }
    void calculateTime()
    {
        StartTime = Time.time;
    }
}
