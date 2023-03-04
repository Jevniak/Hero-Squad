using Systems;

namespace Enemy
{
    public class EnemyHealth : Health
    {
        private EnemySpawnManager enemySpawnManager;
        private int maxHealth;


        private void Awake()
        {
            maxHealth = GetHealth();
            enemySpawnManager = EnemySpawnManager.Instance;
        }

        protected override void Die()
        {
            gameObject.SetActive(false);
            SetHealth(maxHealth);
            enemySpawnManager.EnemyDie();
        }
    }
}
