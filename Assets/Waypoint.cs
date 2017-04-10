using UnityEngine;
using System.Collections;
using UnityEditor;

public class Waypoint : MonoBehaviour {
    public Waypoint travelPath;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Matrix4x4 oldGizmosMatrix = Gizmos.matrix;
        Gizmos.matrix *= cubeTransform;
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(Vector3.zero, new Vector3(1, .1f, 1));
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(1, .1f, 1));
        Gizmos.color = new Color(0, 1, 0, 0.9f);
        for (int i = 0; i < 5; i++)
            Gizmos.DrawWireCube(Vector3.up * i * 0.3f, new Vector3(1, .001f, 1));
        Gizmos.matrix = oldGizmosMatrix;
        if (travelPath)
        {
            Handles.color = Color.green;
            Handles.ArrowCap(0,
                  transform.position,
                  Quaternion.LookRotation(travelPath.transform.position - transform.position, Vector3.up),
                  (travelPath.transform.position - transform.position).magnitude * .75f);
        }
    }
}
