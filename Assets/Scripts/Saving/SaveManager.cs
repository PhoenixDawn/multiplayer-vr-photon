using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveTransform(Transform transform, string id)
    {
        TransformData data = new TransformData
        {
            position = transform.localPosition,
            rotation = transform.localRotation,
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
