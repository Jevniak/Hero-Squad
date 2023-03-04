using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class BotMove : MonoBehaviour, IBotBehavior
    {
        [SerializeField] private float speed;
        [SerializeField] private BotController botController;
        [SerializeField] private EnemyAnimator enemyAnimator;
        private Transform thisTransform;
        private bool isMelee;

        private void Awake()
        {
            thisTransform = GetComponent<Transform>();
            isMelee = botController.GetWeaponData() == null;

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
            transform.LookAt(botController.GetTarget());
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
            if (!isMelee && Vector3.Distance(thisTransform.position, botController.GetTarget().position) < 6f)
            {
                botController.SetBehaviorShoot();
            }
        }

        public void CustomUpdate()
        {
        }
    }
}