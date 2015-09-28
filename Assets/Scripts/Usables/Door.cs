using UnityEngine;
using System;
using System.Collections;

public class Door : UseableObject
{
    private enum DoorState
    {
        stationary,
        opening,
        closing
    }
    private DoorState state;
    private Vector3 closed;
    private Vector3 open;
    private float openTime = 1.5f;
    private bool transitioning;

    void Start()
    {
        closed = transform.position;
        var size = GetComponent<Renderer>().bounds.size;

        open = closed;
        open.x += size.x;

        state = DoorState.stationary;
        transitioning = false;
    }

    public override void Activate()
    {
        if (!transitioning)
        {
            // Must not be doing anything
            transitioning = true;
            state = DoorState.opening;
            moveDoor(() =>
            {
                swapPositions();
                state = DoorState.stationary;
            });
        }
    }

    void Update()
    {
        if (state == DoorState.stationary && transitioning)
        {
            state = DoorState.closing;
            // Must have opened but not closed
            moveDoor(() =>
            {
                swapPositions();
                transitioning = false;
                state = DoorState.stationary;
            });
        }
    }

    private void swapPositions()
    {
        var temp = open;
        open = closed;
        closed = temp;
    }

    private void moveDoor(Action callback)
    {
        StartCoroutine(
            Lerp.move(gameObject.transform, closed, open, openTime, callback));
    }



}
