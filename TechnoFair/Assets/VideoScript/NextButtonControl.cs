using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonControl : ShootableUI
{
    public override void shootClick()
    {
        worldSpaceVideo.SetNextClip();
    }
}
