using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CultureFMP
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;

        public Transform target;
        public LayerMask whatIsGround;
        public LayerMask whatIsPlayer;

        public Vector3 walkPoint;
        private bool walkPointSet;
        public float walkPointRange;

        public float timeBetweenAttacks;
        private bool alreadyAttacked;

        public float sightRange;
        public float attackRange;
        public bool playerInSightRange;
        public bool playerInAttackRange;

        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            
        }

        private void Patroling()
        {

        }

        private void ChasePlayer()
        {

        }

        private void AttackPlayer()
        {

        }
    }
}
