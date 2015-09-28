using UnityEngine;
using System.Collections;

public class AutoClosingDoor : DoorBase
{
    [SerializeField]
    private float openDelay;

    public override void Activate()
    {
        if (state == DoorState.closed) { Open(); }
    }

    void Update()
    {
        if (state == DoorState.open) 
        {
            StartCoroutine(delayClose()); 
        }
    }

    private IEnumerator delayClose()
    {
        yield return new WaitForSeconds(openDelay);
        Close();
    }
}
