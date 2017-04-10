using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Engagement))]
public class EngagementEditor : Editor {

    ReorderableList travelPathList;
    ReorderableList spawnerList;
    // Use this for initialization
    void Start () {
		
	}

    void OnEnable()
    {
        SerializedProperty serializedProperty = serializedObject.FindProperty("travelPaths");
        travelPathList = new ReorderableList(serializedObject, serializedProperty, true, true, true, true);
        travelPathList.drawHeaderCallback = (Rect rect) => {
             EditorGUI.LabelField(rect, "Travel Paths");
         };
        travelPathList.drawElementCallback =
        (Rect rect, int index, bool isActive, bool isFocused) => {
        var element = travelPathList.serializedProperty.GetArrayElementAtIndex(index);
        rect.y += 2;
        EditorGUI.PropertyField(
            new Rect(rect.x, rect.y, 220, EditorGUIUtility.singleLineHeight),
            element, GUIContent.none);
        };

        serializedProperty = serializedObject.FindProperty("spawners");
        spawnerList = new ReorderableList(serializedObject, serializedProperty, true, true, true, true);
        spawnerList.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Spawners");
        };
        spawnerList.drawElementCallback =
        (Rect rect, int index, bool isActive, bool isFocused) => {
            var element = spawnerList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, 220, EditorGUIUtility.singleLineHeight),
                element, GUIContent.none);
        };

    }

    [MenuItem("GameObject/Level/Engagement Zone",false,10)]
    static void CreateEngagement(MenuCommand menuCommand)
    {
        GameObject prefab =Resources.Load("Engagement Zone") as GameObject;
        GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.name = "Engagement Zone";
        GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
        Selection.activeObject = obj;
    }
    // Update is called once per frame
    void Update () {
		
	}

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        travelPathList.DoLayoutList();
        spawnerList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
