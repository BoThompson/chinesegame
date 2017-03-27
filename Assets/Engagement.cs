using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Engagement : MonoBehaviour {

    private bool activated;

    [SerializeField]
    public List<Spawner> spawners;
    public List<Engagement> travelPaths;
    
    Rect region;
   // public ArrayList<GameObject>
	// Use this for initialization
	void Start () {
        activated = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if(!activated && col.transform.tag == "Player")
        {
            activated = true;
            foreach(Spawner s in spawners)
            {
                s.Activate();
            }
        }
    }


    void OnDrawGizmos()
    {
        Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Matrix4x4 oldGizmosMatrix = Gizmos.matrix;
        Gizmos.matrix *= cubeTransform;
        Gizmos.color = new Color(0, 1, 1, 0.5f);
        Gizmos.DrawCube(Vector3.zero, new Vector3(5, .1f, 7));
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(5, .1f, 7));
        Gizmos.color = new Color(0, 1, 1, 0.9f);
        for (int i = 0; i < 5; i++)
            Gizmos.DrawWireCube(Vector3.up * i * 0.3f, new Vector3(5, .001f, 7));
        Gizmos.matrix = oldGizmosMatrix;

        foreach (Spawner s in spawners)
        {
            Handles.color = Color.yellow;
            Handles.ArrowCap(0,
                  s.transform.position,
                  Quaternion.LookRotation(transform.position - s.transform.position, Vector3.up),
                  (transform.position - s.transform.position).magnitude * .75f);
        }       

        foreach (Engagement e in travelPaths)
        {
            Handles.color = Color.green;
            Handles.ArrowCap(0,
                  transform.position,
                  Quaternion.LookRotation(e.transform.position - transform.position, Vector3.up),
                  (e.transform.position - transform.position).magnitude * .75f);
        }
    }
}
