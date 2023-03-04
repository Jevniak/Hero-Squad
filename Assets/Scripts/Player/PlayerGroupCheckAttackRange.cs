using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerGroupCheckAttackRange : MonoBehaviour
    {
        private Transform thisTransform;

        [SerializeField] private LayerMask enemyLayerMask;
        [SerializeField] private List<PlayerShoot> playerShootList;
        [SerializeField] private PlayerGroupRotate playerRotate;
        [SerializeField] private float radius = 8f;
        [SerializeField] private PlayerAnimatorGroup playerAnimatorGroup;

        private void Awake()
        {
            thisTransform = transform;
            foreach (PlayerShoot playerShoot in playerShootList)
            {
                playerShoot.SetRangeBullet(radius);
            }
        }

        private void FixedUpdate()
        {
            int maxColliders = 1;
            Collider[] hitColliders = new Collider[maxColliders];
            int numColliders =
                Physics.OverlapSphereNonAlloc(thisTransform.position, radius, hitColliders, enemyLayerMask);
            playerAnimatorGroup.SetAttack(numColliders != 0);
            if (numColliders != 0)
            {
                
                Vector3 targetPosition = hitColliders[0].transform.position;
                
                playerRotate.RotateToTarget(targetPosition);

                foreach (PlayerShoot playerShoot in playerShootList)
                {
                    playerShoot.Shoot(targetPosition);
                }

            }
            else
            {
                playerRotate.RotateToTarget(Vector3.zero);
            }
        }
    }
}