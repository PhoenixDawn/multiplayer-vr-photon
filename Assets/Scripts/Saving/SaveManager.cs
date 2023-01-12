using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //private string savePath;

    //public Save saves = new Save();
    //public enum SaveableType
    //{
    //    Building,
    //    FarmPlot
    //}
    //[SerializeField]
    //public List<string> allSaveable = new List<string>();

    //private Saveable[] saveables;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //    savePath = Application.persistentDataPath + "/Save.json";
    //    if (!System.IO.File.Exists(savePath))
    //    {
    //        System.IO.File.WriteAllText(savePath, JsonUtility.ToJson(new Save()));
    //    }

    //}

    //private void Start()
    //{
    //    // Find all Saveable objects
    //    saveables = Resources.FindObjectsOfTypeAll<Saveable>();

    //    foreach( var save in saveables)
    //    {
    //        allSaveable.Add($"{save.gameObject.name},  {save.objectTypes[save.objectTypeIndex]}");
    //    }

    //    load();

    //}

    //private void load()
    //{
    //    Save loadedSave = JsonUtility.FromJson<Save>(GetSaveData());
    //    List<Building> hasLoadedBuilding = new List<Building>(); // This is added for buildings possibly not needing to be loaded in scene
    //    foreach(Saveable s in saveables)
    //    {
    //        foreach(Building b in loadedSave.Buildings)
    //        {
    //            if (b.Id == s.ID)
    //            {
    //                s.gameObject.transform.position = b.Position;
    //                s.gameObject.transform.rotation = b.Rotation;
    //                hasLoadedBuilding.Add(b);
    //            }
    //        }

    //        foreach (FarmPlot f in loadedSave.FarmPlots)
    //        {
    //            if (f.ID == s.ID)
    //            {
    //                FarmPlotManager fpm = s.transform.GetComponent<FarmPlotManager>();
    //                fpm.farmPlot.IsTilled = f.IsTilled;
    //                fpm.farmPlot.GrowthStage = f.GrowthStage;
    //                fpm.farmPlot.PlantType = f.PlantType;
    //                Debug.Log("I have been run first");
    //                fpm.load();
    //            }
    //        }
    //    }

    //    foreach (Building b in hasLoadedBuilding)
    //    {
    //        loadedSave.Buildings.Remove(b);
    //    }
    //}

    //private void OnApplicationQuit()
    //{
    //    Save();
    //}

    //private string GetSaveData()
    //{
    //    StreamReader reader = new StreamReader(savePath);
    //    string results = reader.ReadToEnd();
    //    reader.Close();
    //    return results;
    //}

    //private void Save()
    //{
    //    saves = new Save();
    //    foreach (Saveable save in saveables)
    //    {

    //        // Buildings
    //        if (save.objectTypeIndex == (int)SaveableType.Building)
    //        {
    //            saves.Buildings.Add(new Building(save.gameObject.transform.position, save.gameObject.transform.rotation, save.gameObject.name, save.ID));
    //        }

    //        // Farm Plots
    //        if (save.objectTypeIndex == (int)SaveableType.FarmPlot)
    //        {
    //            FarmPlot fp = save.gameObject.GetComponent<FarmPlotManager>().farmPlot;
    //            fp.ID = save.ID;
    //            saves.FarmPlots.Add(fp);
    //        }
    //    }
    //    // Deserialize old save and update with new save data if changes
    //    saves = mergeSaves(saves);

    //    // Save Data to file
    //    System.IO.File.WriteAllText(savePath, JsonUtility.ToJson(saves));
    //}

    //private Save mergeSaves(Save newSave)
    //{
    //    Save oldSave = JsonUtility.FromJson<Save>(GetSaveData());

    //    // Buildings
    //    List<Building> storedBuildings = new List<Building>();
    //    foreach (Building building in oldSave.Buildings)
    //    {
    //        foreach (Building b in newSave.Buildings)
    //        {
    //            if (b.Id == building.Id)
    //            {
    //                building.CopyData(b);
    //                storedBuildings.Add(b);
    //            }
    //        }
    //    }
    //    foreach (Building b in storedBuildings)
    //    {
    //        newSave.Buildings.Remove(b);
    //    }
    //    oldSave.Buildings.AddRange(newSave.Buildings);

    //    // Farm Plots
    //    List<FarmPlot> storedFarmplot = new List<FarmPlot>();
    //    foreach (FarmPlot farmplot in oldSave.FarmPlots)
    //    {
    //        foreach (FarmPlot f in newSave.FarmPlots)
    //        {
    //            if (f.ID == farmplot.ID)
    //            {
    //                farmplot.CopyData(f);
    //                storedFarmplot.Add(f);
    //            }
    //        }
    //    }
    //    foreach (FarmPlot f in storedFarmplot)
    //    {
    //        newSave.FarmPlots.Remove(f);
    //    }

    //    oldSave.FarmPlots.AddRange(newSave.FarmPlots);

    //    return oldSave;
    //}
    public void SaveTransform(Transform transform, string id)
    {
        TransformData data = new TransformData
        {
            position = transform.position,
            rotation = transform.rotation,
            scale = transform.localScale
        };
        SaveData(data, id + ".json");
    }

    public void SaveFarmPlotManager(FarmPlotManager fpm, string id)
    {
        FarmPlot data = fpm.farmPlot;
        SaveData(data, id + ".json");
    }

    private void SaveData(object data, string filename)
    {
        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllText(path, json);
    }

    public T LoadData<T>(string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return default(T);
        }
    }

}
