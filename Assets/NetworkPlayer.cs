using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Unity.XR.CoreUtils;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform head;
    [SerializeField]
    private Transform leftHand;
    [SerializeField]
    private Transform rightHand;

    [SerializeField]
    private Animator leftHandAnimator;
    [SerializeField]
    private Animator rightHandAnimator;


    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;


    private PhotonView photonView;

    public bool isPlayer = false;
    void Start()
    {
        Player rig = FindObjectOfType<Player>();
        photonView = GetComponent<PhotonView>();
        headRig = rig.transform.Find("SteamVRObjects/VRCamera");
        leftHandRig = rig.transform.Find("SteamVRObjects/LeftHand");
        rightHandRig = rig.transform.Find("SteamVRObjects/RightHand");

        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            this.isPlayer = true;

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
            
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);

            UpdateSteamHandAnimation(SteamVR_Input_Sources.LeftHand, leftHandAnimator);
            UpdateSteamHandAnimation(SteamVR_Input_Sources.RightHand, rightHandAnimator);
        }

    }

    void UpdateSteamHandAnimation(SteamVR_Input_Sources targetDevice, Animator handAnimator)
    {
        if (SteamVR_Actions.default_GrabGrip.GetState(targetDevice))
        {
            handAnimator.SetFloat("Grip", 100);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
