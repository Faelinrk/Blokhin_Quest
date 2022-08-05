using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Quest.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
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

        private void Awake()
        {
            playerSearch = GetComponent<PlayerSearch>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            patroolPoint = patroolPoints[0];
            player = GameObject.FindWithTag(Constants.PlayerTag).transform;
        }



        private void FixedUpdate()
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
                            StartCoroutine(ReturnToPatrool());
                        }
                        break;
                    case PatroolStates.Wait:
                        break;
                }
            }
        private IEnumerator ReturnToPatrool()
        {
            for (int i = 0; i < 25; i++)
            {
                yield return new WaitForSeconds(.5f);
                if (playerSearch.LookForPlayer(player, ray, eyes, visionDist))
                {
                    patroolState = PatroolStates.Chacing;
                    StopCoroutine(ReturnToPatrool());
                }
            }
            patroolState = PatroolStates.Patrool;
        }

        
    }
}

