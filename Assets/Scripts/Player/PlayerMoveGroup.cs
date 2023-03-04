using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMoveGroup : MonoBehaviour
    {
        [SerializeField] private PlayerAnimatorGroup playerAnimatorGroup;
        [SerializeField] private FloatingJoystick joystick;
        private Transform thisTransform;
        [SerializeField] private float speed;
        [SerializeField] private PlayerGroupRotate playerGroupRotate;

        private void Awake()
        {
            thisTransform = transform;
            if (playerAnimatorGroup == null)
                playerAnimatorGroup = GetComponent<PlayerAnimatorGroup>();
        }

        private void FixedUpdate()
        {
            Vector2 direction = joystick.Direction;
            Move(direction);
            RotateDirection(direction);
        }

        private void Move(Vector2 direction)
        {
            playerAnimatorGroup.SetMove(direction != Vector2.zero);
            thisTransform.Translate(new Vector3(direction.x, 0, direction.y) * speed * Time.fixedDeltaTime);
        }

        private void RotateDirection(Vector2 direction)
        {
            if (direction != Vector2.zero)
                playerGroupRotate.RotateDirection(direction);
        }
    }
}