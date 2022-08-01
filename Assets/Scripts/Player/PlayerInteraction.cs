using Quest.Interactable;
using UnityEngine;

namespace Quest.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private const string Interaction = "Interaction";
        private Ray ray;

        [SerializeField] private float interactionDistance = 2f;

        private void Update()
        {
            if (Input.GetButtonDown(Interaction))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit,interactionDistance))
                {
                    if (hit.transform.TryGetComponent<Interaction>(out Interaction interaction))
                    {
                        interaction.Interact();
                    }
                }
            }
        }
    }
}

