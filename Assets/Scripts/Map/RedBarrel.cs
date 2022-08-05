using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Map
{
    public class RedBarrel : MonoBehaviour
    {
        [SerializeField] private float radius = 10f;
        [SerializeField] private float explosionForce = 10f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.BulletTag))
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.TryGetComponent<Rigidbody>(out Rigidbody hitRigidbody))
                    {
                        hitRigidbody.AddForce((hitRigidbody.position-transform.position)*explosionForce);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
}

