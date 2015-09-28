using UnityEngine;
using System.Collections;

public class LevelEnd : UseableObject
{
    [SerializeField]
    private string nextLevel;

    public override void Activate()
    {
        Application.LoadLevel(nextLevel);
    }
}
