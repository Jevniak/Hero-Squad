using System.Collections.Generic;
using Enemy;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Systems
{
    public class EnemySpawnManager : MonoBehaviour
    {
        public static EnemySpawnManager Instance;

        private List<GameObject> enemyPool;
        [SerializeField] private TMP_Text textCountAliveEnemy;
        [SerializeField] private List<GameObject> enemyToPool;
        [SerializeField] private int enemyCurrentCount;
        [SerializeField] private int enemyCountIncrease = 5;
        [SerializeField] private int enemyMaxCount = 50;
        private int enemyCountAlive;

        [SerializeField] private Transform target;

        [SerializeField] private List<BoxCollider> spawnZoneList;

        private void Awake()
        {
            Instance = this;
            AddPoolEnemy();
        }

        private void Start()
        {
            StartNewWave();
        }

        public void EnemyDie()
        {
            enemyCountAlive--;
            textCountAliveEnemy.text = $"Alive enemy: {enemyCountAlive}";
            if (enemyCountAlive == 0)
            {
                StartNewWave();
            }
        }

        private void StartNewWave()
        {
            enemyCurrentCount += enemyCountIncrease;
            if (enemyMaxCount < enemyCurrentCount)
                enemyCurrentCount = enemyMaxCount;

            enemyCountAlive = enemyCurrentCount;

            textCountAliveEnemy.text = $"Alive enemy: {enemyCountAlive}";
            
            GameObject tmp;
            for (int i = 0; i < enemyCurrentCount; i++)
            {
                tmp = enemyPool[i];
                tmp.transform.position = GetRandomZonePosition();
                tmp.SetActive(true);
            }
        }

        private Vector3 GetRandomZonePosition()
        {
            BoxCollider spawnZone = spawnZoneList[Random.Range(0, spawnZoneList.Count)];
            Vector3 centerPosition = spawnZone.transform.position;
            Vector3 sizeSpawnZone = spawnZone.size;
            float randomX = Random.Range(-sizeSpawnZone.x / 2, sizeSpawnZone.x / 2);
            float randomZ = Random.Range(-sizeSpawnZone.z / 2, sizeSpawnZone.z / 2);
            Vector3 offsetPosition = new Vector3(randomX, 0, randomZ);
            Vector3 randomPositionInZone = centerPosition + offsetPosition;
            return randomPositionInZone;
        }

        private void AddPoolEnemy()
        {
            GameObject tmp;
            enemyPool = new List<GameObject>();
            for (int i = 0; i < enemyMaxCount; i++)
            {
                tmp = Instantiate(enemyToPool[Random.Range(0,enemyToPool.Count)]);
                tmp.SetActive(false);
                tmp.GetComponent<EnemyInfo>().SetTarget(target);
                
                enemyPool.Add(tmp);
            }
        }
    }
}