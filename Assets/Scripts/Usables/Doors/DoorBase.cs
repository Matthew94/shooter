using UnityEngine;
using System;
using System.Collections;

public class DoorBase : UseableObject
{
    protected DoorState state;
    protected Vector3 closed;
    protected Vector3 open;
    [SerializeField]
    protected float timeToOpen = 1;

    void Start()
    {
        closed = transform.position;
        var size = GetComponent<Renderer>().bounds.size;

        open = transform.position + 
               transform.TransformDirection(Vector3.right * size.x);

        state = DoorState.closed;
    }

    protected void Open()
    {
        if (state != DoorState.closed) { return; }
        state = DoorState.opening;
        StartCoroutine(Lerp.move(transform, closed, open, timeToOpen, () =>
        {
            state = DoorState.open;
        }));
    }

    protected void Close()
    {
        if (state != DoorState.open) { return; }
        state = DoorState.closing;
        StartCoroutine(Lerp.move(transform, open, closed, timeToOpen, () =>
        {
            state = DoorState.closed;
        }));
    }

}
