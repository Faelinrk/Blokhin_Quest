using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Quest.Enemies
{
    public class Patrool : MonoBehaviour
    {
        private enum PatroolStates
        {
            Wait, Patrool, Chacing
        }
        private NavMeshAgent navMeshAgent;
        private Transform patroolPoint;
        private int index;
        private Transform player;
        private Ray ray;
        [SerializeField] private Transform[] patroolPoints;
        [SerializeField] private PatroolStates patroolState;
        [SerializeField] private float visionDist = 25f;
        [SerializeField] private Transform eyes;
        private PlayerSearch playerSearch;

        private void Start()
        {
            playerSearch = GetComponent<PlayerSearch>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            patroolPoint = patroolPoints[0];
            player = GameObject.FindWithTag(Constants.PlayerTag).transform;
        }

        private void Update()
        {
            switch (patroolState)
            {
                case PatroolStates.Patrool:
                    //patrool
                    navMeshAgent.SetDestination(patroolPoint.position);
                    if (Vector3.Distance(transform.position, patroolPoint.position) <= navMeshAgent.stoppingDistance)
                    {
                        index = (index + 1) % patroolPoints.Length;
                        patroolPoint = patroolPoints[index];
                    }
                    if (playerSearch.LookForPlayer(player, ray, eyes, visionDist))
                        patroolState = PatroolStates.Chacing;
                    break;
                case PatroolStates.Chacing:
                    navMeshAgent.SetDestination(player.position);
                    if (!playerSearch.LookForPlayer(player, ray, eyes, visionDist))
                    {
                        patroolState = PatroolStates.Wait;
                        StartCoroutine(ReturnToPatrool());
                    }
                    break;
                case PatroolStates.Wait:
                    break;
            }
        }

        private IEnumerator ReturnToPatrool()
        {
            yield return new WaitForSeconds(5f);
            patroolState = PatroolStates.Patrool;
        }

        
    }
}

