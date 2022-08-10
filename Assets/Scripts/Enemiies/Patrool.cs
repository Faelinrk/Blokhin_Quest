using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Quest.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(PlayerSearch))]
    [RequireComponent(typeof(Animator))]
    public class Patrool : MonoBehaviour
    {
        private enum PatroolStates
        {
            Wait, Patrool, Chacing
        }
        private NavMeshAgent navMeshAgent;
        private PlayerSearch playerSearch;
        private Transform patroolPoint;
        private int index;
        private Transform player;
        private Ray ray;
        private Animator animator;
        
        [SerializeField] private Transform[] patroolPoints;
        [SerializeField] private PatroolStates patroolState;
        [SerializeField] private float visionDist = 25f;
        [SerializeField] private Transform eyes;
        
        private static readonly int Agressive = Animator.StringToHash("Agressive");


        private void Awake()
        {
            playerSearch = GetComponent<PlayerSearch>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
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
                        animator.SetBool(Agressive, true);
                        if (!playerSearch.LookForPlayer(player, ray, eyes, visionDist))
                        {
                            StartCoroutine(ReturnToPatrool());
                            animator.SetBool(Agressive, false);
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

