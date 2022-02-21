using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor : MonoBehaviour
{
    public void StartInteraction(SingleInteractable interactable)
    {
        interactable.StartInteraction(this);
    }

    public void EndInteraction(SingleInteractable interactable)
    {
        interactable.EndInteraction(this);
    }

    public void StartInteraction(MultiInteractable interactable, string name)
    {
        interactable.StartInteraction(name, this);
    }

    public void EndInteraction(MultiInteractable interactable, string name)
    {
        interactable.EndInteraction(name, this);
    }
}
