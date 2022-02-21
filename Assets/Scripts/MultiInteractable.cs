using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiInteractable : Interactable
{
    [SerializeField] 
    public bool canStartMultipleInteractions;

    [SerializeField]
    public List<Interaction> interactions;

    private bool CheckMultipleInteraction()
    {
        if (!canStartMultipleInteractions)
        {
            for (int i = 0; i < interactions.Count; i++)
            {
                if (interactions[i] != null && interactions[i].started)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void StartInteraction(string name, Interactor interactor)
    {
        if (CheckMultipleInteraction())
        {
            StartInteraction(interactor, GetInteractionByName(name));
        }
    }

    public void EndInteraction(string name, Interactor interactor)
    {
        if (CheckMultipleInteraction())
        {
            EndInteraction(interactor, GetInteractionByName(name));
        }
    }

    public Interaction GetInteractionByName(string name)
    {
        if (interactions != null)
        {
            for (int i = 0; i < interactions.Count; i++)
            {
                if (string.Equals(interactions[i].name, name, System.StringComparison.OrdinalIgnoreCase))
                {
                    return interactions[i];
                }
            }
        }
        return null;
    }
}