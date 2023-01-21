using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FarmPlot
{
    public List<bool> IsTilled = new List<bool>();

    public List<int> GrowthStage = new List<int>();

    public List<string> PlantType = new List<string>();

    public string ID;

    public bool isLoaded = false;

    public FarmPlot()
    {
        for (int i = 0; i < 6; i++)
        {
            IsTilled.Add(false);
            GrowthStage.Add(0);
            PlantType.Add("");
        }
    }

    public void CopyData(FarmPlot fp)
    {
        this.IsTilled = fp.IsTilled;
        this.GrowthStage = fp.GrowthStage;
        this.PlantType = fp.PlantType;
    }
}
