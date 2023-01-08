using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    public Vector3 Position;
    public Quaternion Rotation;
    public string Type;
    public string Id = "0";

    public Building(Vector3 position, Quaternion rotation, string type, string id)
    {
        Position = position;
        Rotation = rotation;
        Type = type;
        Id = id;
    }

    public void CopyData(Building building)
    {
        Position = building.Position;
        Rotation = building.Rotation;
    }
}
