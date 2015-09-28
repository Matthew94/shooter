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
        closed = transform.position;
        var size = GetComponent<Renderer>().bounds.size;

        open = closed;
        open.x += size.x;

        state = DoorState.closed;
    }

    void Open()
    {
        if (state != DoorState.closed) { return; }
        state = DoorState.opening;
        StartCoroutine(Lerp.move(transform, closed, open, openTime, () => 
        {
            state = DoorState.open;
        }));
    }

    void Close()
    {
        if (state != DoorState.open) { return; }
        state = DoorState.closing;
        StartCoroutine(Lerp.move(transform, open, closed, openTime, () =>
        {
            state = DoorState.closed;
        }));
    }

}
