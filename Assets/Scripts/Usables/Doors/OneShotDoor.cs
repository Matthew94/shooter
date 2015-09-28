using UnityEngine;
using System.Collections;

public class OneShotDoor : DoorBase
{

    public override void Activate()
    {
        if (state == DoorState.closed)
        {
            Open();
        }
    }

}
