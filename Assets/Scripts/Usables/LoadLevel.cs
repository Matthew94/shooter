using UnityEngine;
using System.Collections;

public class LoadLevel : UseableObject
{
    public string level;

    public override void Activate()
    {
        Application.LoadLevel(level);
    }
}
