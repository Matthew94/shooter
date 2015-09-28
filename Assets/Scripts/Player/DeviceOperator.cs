using UnityEngine;
using System.Collections;

public class DeviceOperator : MonoBehaviour 
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

	void Update () 
    {
	    if (Input.GetButtonDown(AxisCodes.Activate))
        {
            var middleOfScreen = new Vector3(_camera.pixelWidth / 2,
                                             _camera.pixelHeight / 2,
                                             0);

            var ray = _camera.ScreenPointToRay(middleOfScreen);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var hitObject = hit.transform.gameObject;
                var distanceToHit = Vector3.Distance(transform.position,
                                                     hit.transform.position);
                var target = hitObject.GetComponent<UseableObject>();
                if (target && distanceToHit < 10)
                {
                    target.Activate();
                }
            }
        }
	}
}
