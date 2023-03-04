using System;
using Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealth : Health
    {
        protected override void Die()
        {
            GameManager.Instance.Lose();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                TakeDamage(10);
        }
    }
}