using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportTarget;
    public Transform TeleportStart;
    public CharacterController Player;

    public void Teleportation1()
    {
        CharacterController cc = Player.GetComponent<CharacterController>();
        cc.enabled = false;
        Player.transform.position = TeleportTarget.transform.position;
        cc.enabled = true;

        Debug.Log("YES");
    }

    public void Teleportation2()
    {
        CharacterController cc = Player.GetComponent<CharacterController>();
        cc.enabled = false;
        Player.transform.position = TeleportStart.transform.position;
        cc.enabled = true;

        Debug.Log("YES");
    }
}
