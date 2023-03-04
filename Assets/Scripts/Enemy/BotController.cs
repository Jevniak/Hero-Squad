using System;
using System.Collections.Generic;
using Data.Weapon;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(BotMove))]
    public class BotController : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
        
        private Transform target;
        
        
        private Dictionary<Type, IBotBehavior> behaviorsMap;
        private IBotBehavior behaviorCurrent;

        private void Awake()
        {
            InitBehaviors();
            SetBehaviorByDefault();
        }


        private void OnEnable()
        {
            if (behaviorsMap.ContainsKey(typeof(BotMove)))
                SetBehaviorMove();
        }

        public Transform GetTarget()
        {
            return target;
        }
        
        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

        public WeaponData GetWeaponData()
        {
            return weaponData;
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
            behaviorsMap = new Dictionary<Type, IBotBehavior>();

            behaviorsMap[typeof(BotMove)] = GetComponent<BotMove>();
            if (weaponData != null)
                behaviorsMap[typeof(BotShoot)] = GetComponent<BotShoot>();

            
        }
        
        private void SetBehaviorByDefault()
        {
            SetBehaviorMove();
        }
        
        public void SetBehaviorShoot()
        {
            var behavior = GetBehavior<BotShoot>();
            SetBehavior(behavior);
        }
        
        public void SetBehaviorMove()
        {
            var behavior = GetBehavior<BotMove>();
            SetBehavior(behavior);
        }
        
        

        private void SetBehavior(IBotBehavior newBehavior)
        {
            if (behaviorCurrent != null)
                behaviorCurrent.Exit();

            if (newBehavior != null)
            {
                behaviorCurrent = newBehavior;
                behaviorCurrent.Enter();
            }
        }

        
        private IBotBehavior GetBehavior<T>() where T : IBotBehavior
        {
            var type = typeof(T);
            return behaviorsMap[type];
        }

       

        
    }
}