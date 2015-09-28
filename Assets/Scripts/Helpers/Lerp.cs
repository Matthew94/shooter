using UnityEngine;
using System;
using System.Collections;

public static class Lerp
{
    public static IEnumerator
    move(Transform objectToMove, Vector3 startPos,
         Vector3 endPos, float timeToMove, Action callback)
    {
        var startTime = Time.time;

        // Starting with trash values
        var currentDuration = 0f;
        var amountComplete = 0f;

        while (amountComplete <= 1f)
        {
            currentDuration = Time.time - startTime;
            amountComplete = currentDuration / timeToMove;

            objectToMove.position =
                Vector3.Lerp(startPos, endPos, amountComplete);

            yield return null;
        }

        callback();
    }
}
