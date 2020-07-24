using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDebug : MonoBehaviour
{
    bool start = false;
    // Start is called before the first frame update
    void Awake()
    {
        start = true;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        if(start)
            if(BallDebug.debug)
                Gizmos.DrawWireMesh(GetComponent<MeshFilter>().mesh, transform.position, transform.rotation, transform.localScale);
    }
}
