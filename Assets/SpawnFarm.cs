using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFarm : MonoBehaviour
{
    public GameObject farm;

    public GameObject table;
    void Awake()
    {
        //farm = Instantiate(farm);
        if (ES3.KeyExists("Farm"))
        {
            Debug.Log("Farm Found Loading...");
            farm = (GameObject)ES3.Load("Farm");
        }
        else
        {
            Debug.Log("Farm NOT Found ");
            farm = Instantiate(farm);
        }
        farm.transform.position = table.transform.position;
        farm.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    // Update is called once per frame
    void save()
    {
        farm.transform.localScale = new Vector3(1, 1, 1);
        ES3.Save("Farm", farm);
        farm.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    private void OnApplicationQuit()
    {
        save();
    }

    private void OnApplicationPause(bool pause)
    {
        save();
    }
}
