using UnityEngine;

public class CameraControls : MonoBehaviour 
{
    // Use MouseX to rotate the actual player
    // and use MouseY on the camera to look up and down
    // as you don't want to rotate the player up and down
    public enum MouseRotation
    {
        MouseX,
        MouseY,
        None
    }
    public MouseRotation rotationMode;
    
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minVert = -45f;
    public float maxVert = 45f;

    private float rotationX = 0;
    
	void Update() 
    {
        switch(rotationMode)
        {
            case MouseRotation.MouseX:
                var mouseXAxis = Input.GetAxis(AxisCodes.MouseX);
                transform.Rotate(0, sensitivityHor * mouseXAxis, 0);
                break;

            case MouseRotation.MouseY:
                rotationX -= Input.GetAxis(AxisCodes.MouseY) * sensitivityVert;
                rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = 
                    new Vector3(rotationX, rotationY, 0);
                break;

            case MouseRotation.None:
                break;

            default:
                Debug.LogError("You shouldn't be able to reach this code");
                break;
        }
	}
}
