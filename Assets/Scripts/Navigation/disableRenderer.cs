using UnityEngine;
using System.Collections;

public class disableRenderer : MonoBehaviour {

	void Start () 
    {
        var renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
	}

}
