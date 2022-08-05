using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{
    public class Turret : MonoBehaviour
    {
        private Transform player;
        private bool playerVisible;
        private Ray ray;
        [SerializeField] private float visionDist = 10f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletPoint;
        private PlayerSearch playerSearch;

        private void Awake()
        {
            playerSearch = GetComponent<PlayerSearch>();
        }

        private void Start()
        {
            player = GameObject.FindWithTag(Constants.PlayerTag).transform;
            StartCoroutine(Shoot());
        }

        private void Update()
        {
            LookAtPlayer();
            playerVisible = playerSearch.LookForPlayer(player,ray,bulletPoint,visionDist);
        }

        private void LookAtPlayer()
        {
            Vector3 targetDirection = player.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward,targetDirection,rotationSpeed*Time.deltaTime,0f);
            transform.rotation=Quaternion.LookRotation(newDirection);
        }
        
        private IEnumerator Shoot()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(2f);
                if (playerVisible)
                {
                    GameObject bullet = Instantiate(bulletPrefab,bulletPoint.transform.position,bulletPoint.transform.rotation);
                }
            }
        }
    }
}

