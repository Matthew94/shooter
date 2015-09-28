using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Raycasting
{
    public static List<GameObject> 
    raycastsThroughScreen(List<Vector3> coords, Camera camera)
    {
        var hits = new List<GameObject>();

        foreach (var coord in coords)
        {
            var ray = camera.ScreenPointToRay(coord);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hits.Add(hit.transform.gameObject);
            }
        }

        return hits;
    }
}
