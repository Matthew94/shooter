using UnityEngine;
using System.Collections;

public class RobotPatrol : MonoBehaviour {

    [SerializeField]
    private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0) { return; }

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        if (agent.remainingDistance < 0.5f) { GoToNextPoint(); }
    }
}
