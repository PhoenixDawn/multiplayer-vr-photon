using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class SteamVR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
        Debug.Log(SteamVR_Input_Sources.LeftHand);
        Debug.Log(SteamVR_Actions.default_GrabGrip.GetState(SteamVR_Input_Sources.LeftHand));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
