using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlotManager : MonoBehaviour
{
    // Start is called before the first frame update
    public FarmPlot farmPlot;

    private void Start()
    {
        load();
    }

    public void setIsTilled(int index, bool value)
    {
        farmPlot.IsTilled[index] = value;
    }
    public void setPlantType(string json)
    {
        KeyValuePair<int, string> val = JsonUtility.FromJson<KeyValuePair<int, string>>(json);
        farmPlot.PlantType[val.Key] = val.Value;
    }
    public void setGrowthStage(string json)
    {
        KeyValuePair<int, int> val = JsonUtility.FromJson<KeyValuePair<int, int>>(json);
        farmPlot.GrowthStage[val.Key] = val.Value;
    }

    public void load()
    {
        // Load Is tilled
        while (farmPlot == null || farmPlot.isLoaded == false )
        {
            return;
        }
        isFarmable[] isFarmable = this.transform.GetComponentsInChildren<isFarmable>(true);
        for (int i = 0; i < farmPlot.IsTilled.Count; i++)
        {
            isFarmable[i].setTilled(farmPlot.IsTilled[i]);
        }
    }
}
