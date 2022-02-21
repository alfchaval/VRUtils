using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MultiInteractable))]
public class MultiInteractableEditor : Editor
{
    private Interactable interactable;
    private SerializedObject interactableObject;
    private SerializedProperty canInteractProperty;
    private SerializedProperty canStartAlreadyStartedInteractionProperty;
    private SerializedProperty canStartMultipleInteractionsProperty;
    private SerializedProperty interactableProperty;
    private int listSize;
    private bool showInteractions;

    private void OnEnable()
    {
        interactable = (Interactable) target;
        interactableObject = new SerializedObject(interactable);
        canInteractProperty = interactableObject.FindProperty("canInteract");
        canStartAlreadyStartedInteractionProperty = interactableObject.FindProperty("canStartAlreadyStartedInteraction");
        canStartMultipleInteractionsProperty = interactableObject.FindProperty("canStartMultipleInteractions");
        interactableProperty = interactableObject.FindProperty("interactions");
    }

    public override void OnInspectorGUI()
    {
        interactableObject.Update();

        EditorGUILayout.PropertyField(canInteractProperty);
        EditorGUILayout.PropertyField(canStartAlreadyStartedInteractionProperty);
        EditorGUILayout.PropertyField(canStartMultipleInteractionsProperty);

        listSize = interactableProperty.arraySize;
        listSize = EditorGUILayout.IntField("Size", listSize);

        if (listSize != interactableProperty.arraySize)
        {
            while (listSize > interactableProperty.arraySize)
            {
                interactableProperty.InsertArrayElementAtIndex(interactableProperty.arraySize);
            }
            while (listSize < interactableProperty.arraySize)
            {
                interactableProperty.DeleteArrayElementAtIndex(interactableProperty.arraySize - 1);
            }
        }
        EditorGUILayout.BeginHorizontal();
        showInteractions = EditorGUILayout.Foldout(showInteractions, "Actions", true, EditorStyles.foldout);
        EditorGUILayout.EndHorizontal();
        if (showInteractions)
        {
            EditorGUI.indentLevel++;
            for (int i = 0; i < interactableProperty.arraySize; i++)
            {
                SerializedProperty MyListRef = interactableProperty.GetArrayElementAtIndex(i);
                SerializedProperty MyString = MyListRef.FindPropertyRelative("name");
                SerializedProperty MyStartingEvent = MyListRef.FindPropertyRelative("startingAction");
                SerializedProperty MyEndingEvent = MyListRef.FindPropertyRelative("endingAction");

                EditorGUILayout.PropertyField(MyString);
                EditorGUILayout.PropertyField(MyStartingEvent);
                EditorGUILayout.PropertyField(MyEndingEvent);
            }
            EditorGUI.indentLevel--;
        }

        interactableObject.ApplyModifiedProperties();
    }
}