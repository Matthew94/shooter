using UnityEngine;
using System.Collections;

public class MovingTarget : MonoBehaviour
{
    public enum MovementDirection
    {
        Vertical,
        Horizontal,
        Backwards
    }
    public MovementDirection movementDirection;

    // Class should just move left and right forever
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isMoving;

    public float timeToLerp = 1f;
    // Distance of how many widths/heights to move
    public float distanceMultiplier;

    private void swapPositions()
    {
        var temp = startPosition;
        startPosition = endPosition;
        endPosition = temp;
    }

    // Get the time
    // Get end time (startTime + duration)
    // Get percentage moved forward
    // Move it forward
    // When it is reached, swap the variables and start again

    void Start()
    {
        startPosition = transform.position;
        var size = GetComponent<Renderer>().bounds.size;
        float length = 0;
        switch (movementDirection)
        {
            case MovementDirection.Horizontal:
                length = size.x;
                break;
            case MovementDirection.Vertical:
                length = size.y;
                break;
            case MovementDirection.Backwards:
                length = size.z;
                break;
        }

        var distanceToMove = length * distanceMultiplier;
        endPosition = transform.position;
        switch (movementDirection)
        {
            case MovementDirection.Horizontal:
                endPosition.x += distanceToMove;
                break;
            case MovementDirection.Vertical:
                endPosition.y += distanceToMove;
                break;
            case MovementDirection.Backwards:
                endPosition.z += distanceToMove;
                break;
        }
        
        isMoving = false;
        StartCoroutine(backAndForth());
    }

    private IEnumerator backAndForth()
    {
        {
            // Doing a small random delay so all
            // of the items aren't moving in sync
            // which looks bad
            var rand_gen = new System.Random();

            // Four invocations means a total delay of i seconds possible
            var delay = 0.0;
            for (var i = 0; i < 10; i++)
            {
                delay += rand_gen.NextDouble();
            }
            Debug.Log(delay.ToString());
            yield return new WaitForSeconds((float)delay);
        }

        while (true)
        {
            if (!isMoving)
            {
                isMoving = true;
                StartCoroutine(
                    Lerp.move(transform, startPosition, endPosition,
                              timeToLerp, () =>
                              {
                                  isMoving = false;
                                  swapPositions();
                              }));
            }
            yield return null;
        }
    }
}
