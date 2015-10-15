using UnityEngine;
using System.Collections;

public class GoToMenu : UseableObject {

    public override void Activate()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Application.LoadLevel("mainMenu");
    }
}
