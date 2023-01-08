using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public List<Building> Buildings;

    public Save()
    {
        Buildings = new List<Building>();
    }
}
