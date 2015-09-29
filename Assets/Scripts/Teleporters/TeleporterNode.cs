using UnityEngine;

public class TeleporterNode : MonoBehaviour
{
    [SerializeField]
    private BoxCollider teleporterExit;

    void OnTriggerEnter(Collider other)
    {
        if (teleporterExit)
        {
            other.transform.position = teleporterExit.transform.position;
        }
    }

}
