using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EngagementEditor : Editor {

	// Use this for initialization
	void Start () {
		
	}

    [MenuItem("GameObject/Level/Engagement Zone",false,10)]
    static void CreateEngagement(MenuCommand menuCommand)
    {
        GameObject prefab =Resources.Load("Engagement Zone") as GameObject;
        GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
        Selection.activeObject = obj;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
