using System.Collections.Generic;
using BT.Meta.Common.Assets.Characters.MainCharacter;
using BT.Meta.Common.InputHandling;
using BT.Meta.Common.UI.GUITextWithImage;
using BT.Meta.Common.UI.Input;
using BT.Meta.MainScene.Objects;
using BT.Meta.MainScene.UI;
using BT.Meta.MainScene.UI.TopBar;
using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.Counter
{
    public class SObjectsCreator : IEcsRunSystem
    {
        private EcsWorld _world;
        EcsFilter<CSpawnRequest> _spawnFilter;
        EcsFilter<CObject> _cObjectFilter;
        public void Run()
        {
            foreach(var spawnEntityId in _spawnFilter)
            {
                ref var entity = ref _spawnFilter.GetEntity(spawnEntityId);
                ref var spawnEntity = ref _spawnFilter.Get1(spawnEntityId);
                AddNewObject(spawnEntity.ResourceName, spawnEntity.Radius, spawnEntity.Speed, spawnEntity.Points);
                entity.Destroy();
            }
        }
        
        public void AddNewObject(string name, float radius, int speed, float points)
        {
            GameObject obj = Resources.Load<GameObject>(name);
            int numObjects = _cObjectFilter.GetEntitiesCount();
            float angle = numObjects * Mathf.PI * 2 / (numObjects + 1);;
            Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius + Vector3.zero;
            
            var spawnedObject = GameObject.Instantiate(obj, spawnPos, Quaternion.LookRotation(Vector3.forward, spawnPos - Vector3.zero));
            var entity = _world.NewEntity();
            ref var cObj = ref entity.Get<CObject>();
            cObj.Points = points;
            cObj.Timer = 1;
            cObj.Transform = spawnedObject.transform;
            cObj.Animator = spawnedObject.GetComponentInChildren<Animator>();
            ref var cRotator = ref entity.Get<CRotator>();
            cRotator.Speed = speed;
        }
    }
}