using System.Collections;
using System.Collections.Generic;
using Quest.Map;
using UnityEngine;

namespace Quest.Interactable
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private Door door;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                door.Open();
                Destroy(gameObject);
            }
        }
    }

}
