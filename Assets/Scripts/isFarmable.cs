using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFarmable : MonoBehaviour
{
    [SerializeField]
    private int index;

    [SerializeField]
    private int hits;

    public Mesh cube, soil;

    [SerializeField]
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

    public void RemoveHit()
    {
        Debug.Log("I've been hit" + hits);
        if (hits <= 0 && IsTilled)
        {
            return;
        }
        hits -= 1;
        if (hits <= 0)
        {
            setIsTilled(true);
        }
    }
}
