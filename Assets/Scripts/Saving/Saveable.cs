using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saveable : MonoBehaviour
{
    [HideInInspector]
    public string[] objectTypes = new[] { "Building", "FarmPlot" };
    [HideInInspector]
    public int objectTypeIndex = 0;

    [SerializeField]
    public string ID = System.Guid.NewGuid().ToString();

    public void save()
    {

    }

    public void Start()
    {
    }

}
