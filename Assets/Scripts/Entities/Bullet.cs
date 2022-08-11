using System;
using Quest;
using Quest.Common;
using UnityEngine;

namespace  Quest.Entities
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField] private float bulletSpeed = 10;
        [SerializeField] private int damage = 10;
        private const int LiveTime = 3;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            rb.velocity = transform.up * bulletSpeed;
            Destroy(gameObject, LiveTime);
        }
    
        // private void Update()
        // {
        //     //rb.AddForce(transform.up * bulletSpeed);
        // }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.PlayerTag) || other.CompareTag(Constants.EnemyTag))
            {
                if (other.TryGetComponent<HpObject>(out HpObject hpObject))
                {
                    hpObject.GetDamage(damage);
                }
            }
            Destroy(gameObject);
        }
    }
}

