using UnityEngine;
using System.Collections;

public class TeleporterEntrance : MonoBehaviour
{
    [SerializeField]
    private BoxCollider teleporterExit;

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = teleporterExit.transform.position;
    }
}
