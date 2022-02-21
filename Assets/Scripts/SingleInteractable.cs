using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SingleInteractable : Interactable
{
    [SerializeField]
    public Interaction interaction;

    public void StartInteraction(Interactor interactor)
    {
        StartInteraction(interactor, interaction);
    }

    public void EndInteraction(Interactor interactor)
    {
        EndInteraction(interactor, interaction);
    }
}