using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NetworkUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI roomText;

    private void Start()
    {
    }

    private void Update()
    {
        try
        {
            roomText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;

        }
        catch
        {
            return;
        }
    }
}
