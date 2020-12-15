using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(MissionManager))]
public class MissionListEditor : Editor
{
    MissionManager manager;
    SerializedObject getTarget;
    SerializedProperty theList;
    int listSize;

    List<bool> newShowFoldout = new List<bool>();
    bool showfold;

    void OnEnable()
    {
        manager = (MissionManager)target;
        getTarget = new SerializedObject(manager);
        theList = getTarget.FindProperty("missionList");
    }
    
    public override void OnInspectorGUI()
    {
        
        getTarget.Update();
        //LIST SIZE
        EditorGUILayout.LabelField("mission list size");
        listSize = theList.arraySize;
        listSize = EditorGUILayout.IntField("List Size", listSize);

        if(listSize!=theList.arraySize)
        {
            while (listSize > theList.arraySize)
            {
                theList.InsertArrayElementAtIndex(theList.arraySize);
            }
            while (listSize < theList.arraySize)
            {
                theList.DeleteArrayElementAtIndex(theList.arraySize - 1);
            }
        }

        //showfoold
        while (newShowFoldout.Count > theList.arraySize)
        {
            newShowFoldout.RemoveAt(newShowFoldout.Count - 1);
        }
        while (newShowFoldout.Count < theList.arraySize)
        {
            newShowFoldout.Add(true);
        }
        //add button  for aadd mission
        if (GUILayout.Button("ADD A NEW MISSION"))
        {
            manager.missionList.Add(new Mission());
        }
        
        //Display content
        for(int i= 0; i < theList.arraySize; i++)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginVertical(GUI.skin.box);
            newShowFoldout[i] = EditorGUILayout.Foldout(newShowFoldout[i], "Mission" + (i + 1));

            SerializedProperty myListRef = theList.GetArrayElementAtIndex(i);
            SerializedProperty myId = myListRef.FindPropertyRelative("missionId");
            
            SerializedProperty myDescription = myListRef.FindPropertyRelative("description");
            SerializedProperty myActive = myListRef.FindPropertyRelative("active");
            SerializedProperty myPermanentActive = myListRef.FindPropertyRelative("permanentActive");
            SerializedProperty myComplete = myListRef.FindPropertyRelative("missionComplete");

            SerializedProperty myRestart = myListRef.FindPropertyRelative("restartOnNextBall");
            SerializedProperty myStopOnEnd = myListRef.FindPropertyRelative("stopOnBallEnd"); 
            SerializedProperty myResetOnComplete = myListRef.FindPropertyRelative("resetOnComplete");
            
            SerializedProperty myTimeToComplete = myListRef.FindPropertyRelative("timeToComplete");
            SerializedProperty myTriggerMutliBall = myListRef.FindPropertyRelative("canTriggerMultiBall");
            SerializedProperty myScore = myListRef.FindPropertyRelative("score");
            SerializedProperty myAmountToComplete = myListRef.FindPropertyRelative("amountToComplete");
            SerializedProperty myCurrentAmount = myListRef.FindPropertyRelative("currentAmount");


          



            //SHOW COntent
            if (newShowFoldout[i])
            {
                EditorGUILayout.PropertyField(myId);
                EditorGUILayout.PropertyField(myDescription);
                EditorGUILayout.PropertyField(myPermanentActive);
                EditorGUILayout.PropertyField(myActive);
                EditorGUILayout.PropertyField(myTriggerMutliBall);
                EditorGUILayout.PropertyField(myComplete);
                EditorGUILayout.PropertyField(myRestart);
                EditorGUILayout.PropertyField(myStopOnEnd);
                EditorGUILayout.PropertyField(myResetOnComplete);
                EditorGUILayout.PropertyField(myTimeToComplete);
                EditorGUILayout.PropertyField(myScore);
                EditorGUILayout.PropertyField(myAmountToComplete);
                EditorGUILayout.PropertyField(myCurrentAmount);
                
            }
            //REMOVE MISSION BUTTTON
            if (GUILayout.Button("Delete Mission"))
            {
                theList.DeleteArrayElementAtIndex(i);
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
            EditorGUILayout.Separator();
        }
        getTarget.ApplyModifiedProperties();
    }
}
