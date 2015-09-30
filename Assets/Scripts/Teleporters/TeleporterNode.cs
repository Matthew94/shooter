using UnityEngine;

public class TeleporterNode : MonoBehaviour
{
    [SerializeField]
    private BoxCollider teleporterExit;

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();

        if (teleporterExit && player)
        {
            if (!player.teleporting)
            {
                player.teleporting = true;
                other.transform.position = teleporterExit.transform.position;
            }
            else
            {
                player.teleporting = false;
            }
        }
    }

}
