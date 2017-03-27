using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnerEditor : Editor {

	// Use this for initialization
	void Start () {
		
	}

    [MenuItem("GameObject/Level/Enemy Spawner",false,11)]
    static void CreateEngagement(MenuCommand menuCommand)
    {
        GameObject prefab =Resources.Load("Enemy Spawner") as GameObject;
        GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
        Selection.activeObject = obj;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
