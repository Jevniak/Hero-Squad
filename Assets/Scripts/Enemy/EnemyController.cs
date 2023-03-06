using System;
using System.Collections.Generic;
using Data.Weapon;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyMove))]
    public class EnemyController : MonoBehaviour
    {
        private Dictionary<Type, IEnemyBehavior> behaviorsMap;
        private IEnemyBehavior behaviorCurrent;

        [SerializeField] private EnemyInfo enemyInfo;

        public EnemyInfo GetEnemyInfo()
        {
            return enemyInfo;
        }
        
        private void Awake()
        {
            InitBehaviors();
            SetBehaviorByDefault();
            enemyInfo = GetComponent<EnemyInfo>();
        }
        
        private void OnEnable()
        {
            if (behaviorsMap.ContainsKey(typeof(EnemyMove)))
                SetBehaviorMove();
        }
        
        
        private void Update()
        {
            if (behaviorCurrent != null)
                behaviorCurrent.CustomUpdate();
        }

        private void FixedUpdate()
        {
            if (behaviorCurrent != null)
                behaviorCurrent.CustomFixedUpdate();
        }
        
        private void InitBehaviors()
        {
            behaviorsMap = new Dictionary<Type, IEnemyBehavior>();

            behaviorsMap[typeof(EnemyMove)] = GetComponent<EnemyMove>();
            if (enemyInfo.GetWeaponData() != null)
                behaviorsMap[typeof(EnemyShoot)] = GetComponent<EnemyShoot>();

            
        }
        
        private void SetBehaviorByDefault()
        {
            SetBehaviorMove();
        }
        
        public void SetBehaviorShoot()
        {
            var behavior = GetBehavior<EnemyShoot>();
            SetBehavior(behavior);
        }
        
        public void SetBehaviorMove()
        {
            var behavior = GetBehavior<EnemyMove>();
            SetBehavior(behavior);
        }
        
        

        private void SetBehavior(IEnemyBehavior newBehavior)
        {
            if (behaviorCurrent != null)
                behaviorCurrent.Exit();

            if (newBehavior != null)
            {
                behaviorCurrent = newBehavior;
                behaviorCurrent.Enter();
            }
        }

        
        private IEnemyBehavior GetBehavior<T>() where T : IEnemyBehavior
        {
            var type = typeof(T);
            return behaviorsMap[type];
        }

       

        
    }
}