using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportTarget;
    public CharacterController Player;

    private void OnTriggerEnter(Collider other)
    {
        CharacterController cc = Player.GetComponent<CharacterController>();
        cc.enabled = false;
        Player.transform.position = TeleportTarget.transform.position;
        cc.enabled = true;

        Debug.Log("YES");
    }
}
