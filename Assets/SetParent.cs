using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform parent;
    void Start()
    {
        parent = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.parent != parent)
        {
            this.transform.SetParent(parent);
        }
    }
}
