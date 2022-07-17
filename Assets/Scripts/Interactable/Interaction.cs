using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Interactable
{
    enum InteractionCases
    {
        Door,
        Item
    }
    
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private InteractionCases interactionCase;

        public void Interact()
        {
            switch (interactionCase)
            {
                case InteractionCases.Door:
                    Door door = GetComponentInParent<Door>();
                    if (door.IsOpened)
                    {
                        door.Interact();
                    }
                    break;
                case InteractionCases.Item:
                    break;
            }
        }
    }
}

