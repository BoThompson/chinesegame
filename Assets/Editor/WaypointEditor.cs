using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointEditor : Editor {
   
	// Use this for initialization
	void Start () {
		
	}

    [MenuItem("GameObject/Level/Waypoint",false,12)]
    static void CreateEngagement(MenuCommand menuCommand)
    {
        GameObject prefab =Resources.Load("Waypoint") as GameObject;
        GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.name = "Waypoint";
        GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
        Selection.activeObject = obj;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
