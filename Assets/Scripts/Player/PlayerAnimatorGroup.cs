using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimatorGroup : MonoBehaviour
    {
        [SerializeField] private List<Animator> animatorList;
        private bool moved;
        private bool attacked;

        public void SetMove(bool state)
        {
            if (moved != state)
            {
                moved = state;
                SetAnimBool("Move", state);
            }
        }

        public void SetAttack(bool state)
        {
            if (!attacked.Equals(state))
            { 
                attacked = state;
                SetAnimBool("Attack", state);
            }
        }

        private void SetAnimBool(string animationName, bool animationState)
        {
            foreach (Animator animator in animatorList)
            {
                animator.SetBool(animationName, animationState);
            }
        }
    }
}