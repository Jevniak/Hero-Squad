using UnityEngine;

namespace Data.Weapon
{
    [CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 51)]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private int attackDamage;
        [SerializeField] private float attackCooldown;
        
        public int AttackDamage => attackDamage;
        public float AttackCooldown => attackCooldown;
    }
}
