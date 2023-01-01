using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterial : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Material[] materials;
    void Start()
    {
        this.GetComponent<MeshRenderer>().materials = materials;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
