using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace CultureFMP
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAI : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Vector3 _transformPosition;
        private bool _walkPointSet;
        private bool _alreadyAttacked;

        public Transform target;
        [SerializeField] private GameObject[] closestTargets;
        public LayerMask whatIsGround;
        public LayerMask whatIsPlayer;
        public float walkPointRange;
        public float sightRange;
        public float attackRange;
        public float timeBetweenAttacks;
        public Vector3 walkPoint;

        [SerializeField] private  bool isMoving = true; 
        public bool playerInSightRange;
        public bool playerInAttackRange;
        

        private void Awake()
        {
            target = null;
            target = GameObject.FindWithTag("Player").transform;
            _agent = GetComponent<NavMeshAgent>();
        }

        private Transform TargetWithinRange()
        {
            closestTargets = GameObject.FindGameObjectsWithTag("Ally");
            float _closestDistance = Mathf.Infinity;
            Transform _target = null;

            foreach (GameObject _enemies in closestTargets)
            {
                var _currentDistance = Vector3.Distance(_transformPosition, _enemies.transform.position);

                if (_currentDistance < _closestDistance)
                {
                    _closestDistance = _currentDistance;
                    _target = _enemies.transform;
                }
            }

            return _target;
        }

        private void Update()
        {
            _transformPosition = transform.position;
            
            playerInSightRange = Physics.CheckSphere(_transformPosition, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(_transformPosition, attackRange, whatIsPlayer);

            if (!playerInAttackRange && !playerInSightRange && isMoving) Patrolling();
            if (!playerInAttackRange && playerInSightRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }

        private void Patrolling()
        {
            if (!_walkPointSet) SearchWalkPoint();

            _agent.SetDestination(walkPoint);

            Vector3 _distanceToPosition = _transformPosition - walkPoint;

            if (_distanceToPosition.magnitude < 1)
                _walkPointSet = false;
        }

        private void SearchWalkPoint()
        {
            float _randomZ = Random.Range(-walkPointRange, walkPointRange);
            float _randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(_transformPosition.x + _randomX, _transformPosition.y,
                _transformPosition.z + _randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2, whatIsGround))
                _walkPointSet = true;
        }

        private void ChasePlayer()
        {
            _agent.SetDestination(target.position);
        }

        private void AttackPlayer()
        {
            _agent.SetDestination(_transformPosition);
            
            transform.LookAt(target);

            if (!_alreadyAttacked)
            {
                Debug.Log($"Attacked {target}");
                
                _alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }

        private void ResetAttack()
        {
            _alreadyAttacked = false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_transformPosition, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_transformPosition, sightRange);
        }
    }
}
