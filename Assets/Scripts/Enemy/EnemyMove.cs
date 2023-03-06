using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour, IEnemyBehavior
    {
        [SerializeField] private float speed;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private EnemyAnimator enemyAnimator;
        private Transform target;
        private Transform thisTransform;
        private bool isMelee;

        private void Awake()
        {
            thisTransform = transform;
            isMelee = enemyController.GetEnemyInfo().GetWeaponData() == null;
        }

        private void Start()
        {
            
            target = enemyController.GetEnemyInfo().GetTarget();

        }

        public void Enter()
        {
            
            if (isMelee)
            {
                enemyAnimator.SetRunMelee(true);
            }
            else
            {
                enemyAnimator.SetRunWithWeapon(true);
            }
        }

        public void Exit()
        {
            if (isMelee)
            {
                enemyAnimator.SetRunMelee(false);
            }
            else
            {
                enemyAnimator.SetRunWithWeapon(false);
            }
        }

        public void CustomFixedUpdate()
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
            if (!isMelee && Vector3.Distance(thisTransform.position, target.position) < 6f)
            {
                enemyController.SetBehaviorShoot();
            }
        }

        public void CustomUpdate()
        {
        }
    }
}