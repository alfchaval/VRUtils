using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    public bool canInteract = true;
    [SerializeField]
    public bool canStartAlreadyStartedInteraction;

    protected void StartInteraction(Interactor interactor, Interaction interaction)
    {
        if (canInteract && interaction != null)
        {
            UnityEvent<Interactor> action = interaction.startingAction;
            if (action != null)
            {
                if (!interaction.started || canStartAlreadyStartedInteraction)
                {
                    interaction.started = true;
                    action.Invoke(interactor);
                }
            }
        }
    }

    protected void EndInteraction(Interactor interactor, Interaction interaction)
    {
        if (canInteract && interaction != null)
        {
            UnityEvent<Interactor> action = interaction.endingAction;
            if (action != null)
            {
                interaction.started = false;
                action.Invoke(interactor);
            }
        }
    }

    public void CanInteract(bool b)
    {
        canInteract = b;
    }

    [System.Serializable]
    public class Interaction
    {
        [SerializeField]
        public string name = "interaction";
        [SerializeField]
        public UnityEvent<Interactor> startingAction;
        [SerializeField]
        public UnityEvent<Interactor> endingAction;

        public bool started = false;
    }
}