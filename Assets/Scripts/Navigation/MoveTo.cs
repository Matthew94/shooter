using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    public Transform goal;

    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

}
