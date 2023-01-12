using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFarmable : MonoBehaviour
{
    [SerializeField]
    private int index;

    public Mesh cube, soil;

    private bool IsTilled = false;

    public void setIsTilled(bool value)
    {
        FarmPlotManager fpm = this.transform.GetComponentInParent<FarmPlotManager>();
        fpm.setIsTilled(index, value);
        setTilled(value);
    }

    public void setTilled(bool isTilled)
    {
        IsTilled = isTilled;
        if (isTilled)
        {
            this.GetComponent<MeshFilter>().mesh = cube;
        }
    }
}
