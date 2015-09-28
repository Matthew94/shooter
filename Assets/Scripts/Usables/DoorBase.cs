using UnityEngine;
using System;
using System.Collections;

public class DoorBase : UseableObject
{
    private enum DoorState
    {
        opening,
        closing,
        open,
        closed
    }
    private DoorState state;
    private Vector3 closed;
    private Vector3 open;
    [SerializeField]
    private float openTime;

    void Start()
    {

    }

    public override void Activate()
    {

    }


}
