using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFarm : MonoBehaviour
{
    public GameObject farmPrefab;
    public Transform AnchorPoint;

    private void Start()
    {
        farmPrefab = Instantiate(farmPrefab);
        farmPrefab.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        farmPrefab.transform.position = new Vector3(farmPrefab.transform.position.x, 0.85f, farmPrefab.transform.position.z);
    }
}
