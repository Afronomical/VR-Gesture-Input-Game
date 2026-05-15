using UnityEngine;
using Unity.Entities;


//Following FreedomCoding Tutorial https://www.youtube.com/watch?v=18f2LeIXGo4
namespace ECS
{
    //These are the values I want to be added to the entity
    public class CubeSpawnerAuthoring : MonoBehaviour
    {
        public GameObject prefab;
        public float spawnRate;
    }

    //This is the process of adding said data to the entity
    class CubeSpawnerBaker : Baker<CubeSpawnerAuthoring>
    {
        public override void Bake(CubeSpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new CubeSpawnerComponent
            {
                prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
                spawnPos = authoring.transform.position,
                nextSpawnTime = 0.0f,
                spawnRate = authoring.spawnRate,

            });
        }
    }
}

