using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour
{
    [SerializeField]
    private string firstLevel;

    public void startGame()
    {
        Application.LoadLevel(firstLevel);
    }

}
