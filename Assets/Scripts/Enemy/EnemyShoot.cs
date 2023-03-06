using System;
using System.Collections;
using Data.Weapon;
using UnityEngine;
using Weapon;

namespace Enemy
{
    public class EnemyShoot : MonoBehaviour, IEnemyBehavior
    {
        [SerializeField] private float distance = 6f;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private Transform bulletStartTransform;
        [SerializeField] private Bullet prefabBullet;
        [SerializeField] private EnemyAnimator enemyAnimator;
        private Transform thisTransform;
        private Transform target;
        private bool canShoot = true;
        private int damage;
        private float cooldown;

        private void Awake()
        {
            thisTransform = transform;
        }

        private void Start()
        {
            WeaponData weaponData = enemyController.GetEnemyInfo().GetWeaponData();
            damage = weaponData.AttackDamage;
            cooldown = weaponData.AttackCooldown;
            target = enemyController.GetEnemyInfo().GetTarget();
        }

        public void Enter()
        {
            enemyAnimator.SetShoot(true);
        }

        public void Exit()
        {
            enemyAnimator.SetShoot(false);
        }

        public void CustomUpdate()
        {
        }

        public void CustomFixedUpdate()
        {
            thisTransform.LookAt(target);

            if (Vector3.Distance(thisTransform.position, target.position) > distance)
            {
                enemyController.SetBehaviorMove();
            } else if (canShoot)
            {
                canShoot = false;
                Vector3 position = bulletStartTransform.position;
                Vector3 targetPosition = target.position;
                targetPosition.y = position.y;
                Bullet bullet = Instantiate(prefabBullet, position, Quaternion.identity);
                bullet.SetDamage(damage);
                bullet.SetDirection((targetPosition - position).normalized);
                bullet.SetMaxDistance(6f);
                StartCoroutine(ShootCooldown());
            }
        }

        private IEnumerator ShootCooldown()
        {
            yield return new WaitForSeconds(cooldown);
            canShoot = true;
        }
    }
}