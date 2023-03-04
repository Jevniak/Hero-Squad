using System;
using System.Collections;
using Data.Weapon;
using UnityEngine;
using Weapon;

namespace Enemy
{
    public class BotShoot : MonoBehaviour, IBotBehavior
    {
        [SerializeField] private float distance = 6f;
        [SerializeField] private BotController botController;
        [SerializeField] private Transform bulletStartTransform;
        [SerializeField] private Bullet prefabBullet;
        [SerializeField] private EnemyAnimator enemyAnimator;
        private Transform thisTransform;
        private bool canShoot = true;
        private int damage;
        private float cooldown;

        private void Awake()
        {
            thisTransform = transform;
            WeaponData weaponData = GetComponent<BotController>().GetWeaponData();
            damage = weaponData.AttackDamage;
            cooldown = weaponData.AttackCooldown;
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
            thisTransform.LookAt(botController.GetTarget());

            if (Vector3.Distance(thisTransform.position, botController.GetTarget().position) > distance)
            {
                botController.SetBehaviorMove();
            } else if (canShoot)
            {
                canShoot = false;
                Vector3 position = bulletStartTransform.position;
                Vector3 targetPosition = botController.GetTarget().position;
                targetPosition.y = position.y;
                Bullet bullet = Instantiate(prefabBullet, position, Quaternion.identity);
                bullet.SetDamage(damage);
                bullet.SetDirection((targetPosition - position).normalized);
                bullet.SetMaxDistance(6f);
                StartCoroutine(ShootCooldown());
            }
        }

        public IEnumerator ShootCooldown()
        {
            yield return new WaitForSeconds(cooldown);
            canShoot = true;
        }
    }
}