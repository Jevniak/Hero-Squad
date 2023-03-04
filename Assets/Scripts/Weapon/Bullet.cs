using Enemy;
using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;

        private int damage;
        private Vector3 direction;
        private float maxDistance = 1;
        private Transform thisTransform;
        private Vector3 startPosition;

        private void Awake()
        {
            thisTransform = transform;
            startPosition = thisTransform.position;
        }
    

        public void SetMaxDistance(float newMaxDistance)
        {
            maxDistance = newMaxDistance;
        }
    
        public void SetDirection(Vector3 newDirection)
        {
            direction = newDirection;
        }
    
        public void SetDamage(int newDamage)
        {
            damage = newDamage;
        }

        private void FixedUpdate()
        {
            transform.Translate(direction * speed * Time.fixedDeltaTime);
            if (Vector3.Distance(startPosition, thisTransform.position) >= maxDistance)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth health))
            {
                
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}