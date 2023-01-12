using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saveable : MonoBehaviour
{
    public bool PositionRotation, FarmManager = false;

    [SerializeField]
    public string ID = System.Guid.NewGuid().ToString();

    private SaveManager saveManager;

    private string savePath;
    private void Awake()
    {
        saveManager = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<SaveManager>();
        load();
    }

    void load()
    {
        if (PositionRotation)
        {
            TransformData savedObject = saveManager.LoadData<TransformData>(ID + ".json");
            this.transform.position = savedObject.position;
            this.transform.rotation = savedObject.rotation;
            this.transform.localScale = savedObject.scale;
        }

        if (FarmManager)
        {
            FarmPlot savedObject = saveManager.LoadData<FarmPlot>(ID + ".json");
            this.GetComponent<FarmPlotManager>().farmPlot = savedObject;
        }
    }

    private void OnApplicationQuit()
    {
        if (PositionRotation)
        {
            saveManager.SaveTransform(this.gameObject.transform, ID);
        }

        if (FarmManager)
        {
            saveManager.SaveFarmPlotManager(this.GetComponent<FarmPlotManager>(), ID);
        }
    }

}
