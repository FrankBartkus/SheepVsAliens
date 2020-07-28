using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CopyLineToAll : MonoBehaviour
{
    LineRenderer line;
    string tagToCopy;
    Vector3[] positions = new Vector3[10];
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        tagToCopy = gameObject.tag;
        count = line.GetPositions(positions);
        foreach (GameObject copy in GameObject.FindGameObjectsWithTag(tagToCopy))
        {
            if(copy.GetComponent<LineRenderer>() == null)
            {
                UnityEngine.Debug.Log(copy.name);
                copy.AddComponent<LineRenderer>().SetPositions(positions);
            }
        }
    }
}
