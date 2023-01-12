using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFarmingTool : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        isFarmable farmable = collision.gameObject.GetComponent<isFarmable>();
        if (farmable)
        {
            farmable.RemoveHit();
        }
    }
}
