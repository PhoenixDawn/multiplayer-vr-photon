using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isFarmable : MonoBehaviour
{
    [SerializeField]
    private int index;

    public void setIsTilled(bool value)
    {
        FarmPlotManager fpm = this.transform.GetComponentInParent<FarmPlotManager>();
        fpm.setIsTilled(index, value);
        Debug.Log("I am being run!");
    }
}
