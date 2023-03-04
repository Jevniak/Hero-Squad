using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private bool moved;
        private bool attacked;

        public void SetRunMelee(bool state)
        {
            if (moved != state)
            {
                moved = state;
                SetAnimBool("Run", state);
            }
        }

        public void SetRunWithWeapon(bool state)
        {
            if (moved != state)
            {
                moved = state;
                SetAnimBool("RunWithWeapon", state);
            }
        }

        public void SetShoot(bool state)
        {
            if (!attacked.Equals(state))
            {
                attacked = state;
                SetAnimBool("Shoot", state);
            }
        }

        private void SetAnimBool(string animationName, bool animationState)
        {
            animator.SetBool(animationName, animationState);
        }
    }
}