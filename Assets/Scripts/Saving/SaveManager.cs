using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string savePath;

    public Save saves = new Save();
    public enum SaveableType
    {
        Building,
        FarmPlot
    }
    [SerializeField]
    public List<string> allSaveable = new List<string>();

    private Saveable[] saveables;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        savePath = Application.persistentDataPath + "/Save.json";
        if (!System.IO.File.Exists(savePath))
        {
            System.IO.File.WriteAllText(savePath, JsonUtility.ToJson(new Save()));
        }

    }

    private void Start()
    {
        // Find all Saveable objects
        saveables = Resources.FindObjectsOfTypeAll<Saveable>();
        
        foreach( var save in saveables)
        {
            allSaveable.Add($"{save.gameObject.name},  {save.objectTypes[save.objectTypeIndex]}");
        }

        load();
        
    }

    private void load()
    {
        Save loadedSave = JsonUtility.FromJson<Save>(GetSaveData());
        List<Building> hasLoaded = new List<Building>();
        foreach(Saveable s in saveables)
        {
            foreach(Building b in loadedSave.Buildings)
            {
                if (b.Id == s.ID)
                {
                    s.gameObject.transform.position = b.Position;
                    s.gameObject.transform.rotation = b.Rotation;
                    hasLoaded.Add(b);
                }
            }
        }
        foreach (Building b in hasLoaded)
        {
            loadedSave.Buildings.Remove(b);
        }
    }

    private void save()
    {
        saves = new Save();
        foreach(Saveable save in saveables)
        {
            Debug.Log(save.gameObject.transform.position);
            if (save.objectTypeIndex == (int)SaveableType.Building)
            {
                saves.Buildings.Add(new Building(save.gameObject.transform.position, save.gameObject.transform.rotation, save.gameObject.name, save.ID));
            }
        }
        // Deserialize old save and update with new save data if changes
        saves = mergeSaves(saves);

        // Save Data to file
        System.IO.File.WriteAllText(savePath, JsonUtility.ToJson(saves));
    }

    private Save mergeSaves(Save newSave)
    {
        Save oldSave = JsonUtility.FromJson<Save>(GetSaveData());
        List<Building> storedBuildings = new List<Building>();
        foreach(Building building in oldSave.Buildings)
        {
            foreach(Building b in newSave.Buildings)
            {
                if (b.Id == building.Id)
                {
                    building.CopyData(b);
                    storedBuildings.Add(b);
                }
            }
        }
        foreach(Building b in storedBuildings)
        {
            newSave.Buildings.Remove(b);
        }
        oldSave.Buildings.AddRange(newSave.Buildings);
        return oldSave;
    }

    private void OnApplicationQuit()
    {
        save();
    }

    private string GetSaveData()
    {
        StreamReader reader = new StreamReader(savePath);
        string results = reader.ReadToEnd();
        reader.Close();
        return results;
    }
}
