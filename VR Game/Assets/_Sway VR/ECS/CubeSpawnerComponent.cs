using Unity.Entities;
using Unity.Mathematics;


//Following FreedomCoding Tutorial https://www.youtube.com/watch?v=18f2LeIXGo4
public struct CubeSpawnerComponent : IComponentData
{
    //All the variables we'd need or would like to adjust for the cube spawner
    public Entity prefab;

    public float3 spawnPos;
    public float nextSpawnTime;
    public float spawnRate;

}

