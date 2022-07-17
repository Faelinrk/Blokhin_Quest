using System;
using UnityEngine;

namespace Quest.Interactable
{
    
    public class Key : MonoBehaviour
    {
        [SerializeField] private Door door;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Constants.PlayerTag)) return;
            door.IsOpened=true;
            Destroy(gameObject);
        }
    }

}
