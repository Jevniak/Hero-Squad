using System;
using System.Collections;
using System.Collections.Generic;
using Data.Weapon;
using UnityEngine;
using Weapon;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Bullet prefabBullet;
        [SerializeField] private WeaponData weaponData;
        [SerializeField] private Transform bulletStartTransform;
        private float shootCooldown;
        private int shootDamage;

        private bool canShoot = true;
        private Coroutine shootDelay;
        private float rangeBullet;

        public void SetRangeBullet(float newRangeBullet)
        {
            rangeBullet = newRangeBullet;
        }

        private void Awake()
        {
            shootCooldown = weaponData.AttackCooldown;
            shootDamage = weaponData.AttackDamage;
        }

        public void Shoot(Vector3 target)
        {
            if (canShoot && shootDelay == null)
            {
                canShoot = false;
                Vector3 position = bulletStartTransform.position;
                target.y = position.y;
                Bullet bullet = Instantiate(prefabBullet, position, Quaternion.identity);
                bullet.SetDamage(shootDamage);
                bullet.SetDirection((target - position).normalized);
                bullet.SetMaxDistance(rangeBullet);
                shootDelay = StartCoroutine(ShootDelay());
            }
        }

        private IEnumerator ShootDelay()
        {
            yield return new WaitForSeconds(shootCooldown);
            canShoot = true;
            shootDelay = null;
        }
    }
}