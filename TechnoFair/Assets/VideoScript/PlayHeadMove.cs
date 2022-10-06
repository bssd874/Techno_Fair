using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHeadMove : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public void MovePlayHead(double playedFraction)
    {
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, (float)playedFraction);

    }
}
