using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    public Vector3 BlockSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BlockSize = this.transform.localScale;
    }
}
