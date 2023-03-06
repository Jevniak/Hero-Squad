using Data.Weapon;
using UnityEngine;

namespace Enemy
{
    public class EnemyInfo : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
        private Transform target;
        
        public Transform GetTarget()
        {
            return target;
        }
        
        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        public WeaponData GetWeaponData()
        {
            return weaponData;
        }
    }
}