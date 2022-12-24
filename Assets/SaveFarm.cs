using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFarm : MonoBehaviour
{
    public GameObject farm;
    // Start is called before the first frame update
    void Awake()
    {
        //farm = Instantiate(farm);
        if (ES3.KeyExists("Farm"))
        {
            farm = (GameObject)ES3.Load("Farm");
        }
        else
        {
            farm = Instantiate(farm);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void save()
    {
        ES3.Save("Farm", farm);
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
