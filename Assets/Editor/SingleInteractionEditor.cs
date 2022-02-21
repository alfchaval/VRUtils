using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SingleInteractable))]
public class SingleInteractionEditor : Editor
{
    private Interactable interactable;
    private SerializedObject interactableObject;
    private SerializedProperty canInteractProperty;
    private SerializedProperty canStartAlreadyStartedInteractionProperty;
    private SerializedProperty interactionProperty;

    private void OnEnable()
    {
        interactable = (Interactable) target;
        interactableObject = new SerializedObject(interactable);
        canInteractProperty = interactableObject.FindProperty("canInteract");
        canStartAlreadyStartedInteractionProperty = interactableObject.FindProperty("canStartAlreadyStartedInteraction");
        interactionProperty = interactableObject.FindProperty("interaction");
    }

    public override void OnInspectorGUI()
    {
        interactableObject.Update();

        EditorGUILayout.PropertyField(canInteractProperty);
        EditorGUILayout.PropertyField(canStartAlreadyStartedInteractionProperty);

        SerializedProperty MyStartingEvent = interactionProperty.FindPropertyRelative("startingAction");
        SerializedProperty MyEndingEvent = interactionProperty.FindPropertyRelative("endingAction");

        EditorGUILayout.PropertyField(MyStartingEvent);
        EditorGUILayout.PropertyField(MyEndingEvent);

        interactableObject.ApplyModifiedProperties();
    }
}