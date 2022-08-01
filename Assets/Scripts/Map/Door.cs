using System;
using UnityEngine;

namespace Quest.Interactable
{
    [RequireComponent(typeof(Animator))]
    public class Door : MonoBehaviour
    {
        private Animator animator;
        private const string IsOpenAnim = "OpenDoor";
        [SerializeField] private bool isOpened = false;
        public bool IsOpened
        {
            get => isOpened;
            set => isOpened = value;
        }
        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void Interact()
        {
            if (!isOpened) return;
            animator.SetBool(IsOpenAnim, !animator.GetBool(IsOpenAnim));
        }
    }

}
