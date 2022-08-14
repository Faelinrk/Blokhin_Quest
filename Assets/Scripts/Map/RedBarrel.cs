using System;
using System.Collections;
using System.Collections.Generic;
using Quest.Common;
using UnityEngine;

namespace Quest.Map
{
    public class RedBarrel : MonoBehaviour
    {
        [SerializeField] private float radius = 10f;
        [SerializeField] private float explosionForce = 10f;
        [SerializeField] private ParticleSystem explosionParticles;
        [SerializeField] private int dmg = 25;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.BulletTag))
            {
                explosionParticles.Play();
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<AudioSource>().Play();
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.TryGetComponent<Rigidbody>(out Rigidbody hitRigidbody))
                    {
                        hitRigidbody.AddForce((hitRigidbody.position-transform.position)*explosionForce);
                    }

                    if (hitCollider.gameObject.CompareTag(Constants.EnemyTag) || hitCollider.gameObject.CompareTag(Constants.PlayerTag))
                    {
                        hitCollider.gameObject.GetComponent<HpObject>().GetDamage(dmg);
                    }
                }
                Destroy(gameObject,4f);
            }
        }
    }
}

