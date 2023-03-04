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
    public class SObjectsCreator : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        List<GameObject> _objectsInCircle = new List<GameObject>();
        EcsFilter<CSpawnRequest> _spawnFilter;
        public void Init()
        {
            // GameObject obj = Resources.Load<GameObject>("Cat");
            // for(int i = 0; i < 20; i++)
            // {
            //     float angle = i * Mathf.PI * 2 / 20;
            //     Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * 2 + Vector3.zero;
            //     var go = GameObject.Instantiate(obj, spawnPos, Quaternion.LookRotation(Vector3.forward, spawnPos - Vector3.zero));
            //     var entity = _world.NewEntity();
            //     ref var cObj = ref entity.Get<CObject>();
            //     cObj.Points = 1;
            //     cObj.Timer = 1;
            //     cObj.Transform = go.transform;
            //     ref var cRotator = ref entity.Get<CRotator>();
            //     cRotator.Speed = 40;
            //     _objectsInCircle.Add(go);
                
            // }
        }
        public void Run()
        {
            foreach(var spawnEntityId in _spawnFilter)
            {
                ref var entity = ref _spawnFilter.GetEntity(spawnEntityId);
                ref var spawnEntity = ref _spawnFilter.Get1(spawnEntityId);
                AddNewObject(spawnEntity.ResourceName);
                entity.Destroy();
            }
        }
        
        public void AddNewObject(string name)
        {
            GameObject obj = Resources.Load<GameObject>("Cat");
            int numObjects = _objectsInCircle.Count;
            float angle = numObjects * Mathf.PI * 2 / (numObjects + 1);;
            Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * 2 + Vector3.zero;
            
            var spawnedObject = GameObject.Instantiate(obj, spawnPos, Quaternion.LookRotation(Vector3.forward, spawnPos - Vector3.zero));
            var entity = _world.NewEntity();
            ref var cObj = ref entity.Get<CObject>();
            cObj.Transform = spawnedObject.transform;
            ref var cRotator = ref entity.Get<CRotator>();
            cRotator.Speed = 40;

            _objectsInCircle.Add(spawnedObject);
        }
    }
}