using UnityEngine;
using System.Collections;

public class Door : DoorBase
{
    public override void Activate()
    {
        if (state == DoorState.closed)
        {
            Open();
        }
        else if (state == DoorState.open)
        {
            Close();
        }
    }
}
