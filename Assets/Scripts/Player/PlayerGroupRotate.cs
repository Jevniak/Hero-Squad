using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerGroupRotate : MonoBehaviour
    {
        private bool lookAt;
        [SerializeField] private List<Transform> playerList;
        

        public void RotateDirection(Vector2 direction)
        {
            if (!lookAt && direction != Vector2.zero)
            {
                foreach (Transform player in playerList)
                {
                    player.eulerAngles = new Vector3(0,
                        Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI, 0);
                }
            }
        }

        public void RotateToTarget(Vector3 targetPosition)
        {
            lookAt = targetPosition != Vector3.zero;
            if (lookAt)
            {
                foreach (Transform player in playerList)
                {
                    player.LookAt(targetPosition);
                }
                
            }
        }
    }
}