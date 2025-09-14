using UnityEngine;

public class RockSummon_Ability : Ability
{
    
    [Tooltip("The furthest away the player can look to spawn a rock")]
    [SerializeField] private float viewRange = 5f;
    [Tooltip("If the distance between the player and a rock's spawn position is less than this value, \n it will not spawn")]
    [SerializeField] private float tooCloseDistance = 2f;
    [Tooltip("The furthest distance downwards that a rock can spawn from the point the player is looking at")]
    [SerializeField] private float maxFloorDistance = 2f;

    [Tooltip("Rocks will only spawn above this layer")]
    public LayerMask rockSpawnLayers;

    [SerializeField] GameObject objectToSpawn;
    [SerializeField] ParticleSystem summonParticle;

    ParticleSystem summonedParticlesInstance;
    Vector3 offset = new Vector3(0, 0, 5);
    Quaternion offsetRot = new Quaternion(0, 0, 0, 0);

    protected override void Start()
    {
        //base.Start();
        //OnActivateAbility += Spawn;
        GestureManager.OnGestureStarted += CheckGesture;
    }

    void CheckGesture(GestureDataSO gesture)
    {
        if (!isCooldownComplete) return;

        if (gesture == requiredGestures[gestureIndex])
        {

            gestureIndex++;

            if (gestureIndex >= requiredGestures.Length)
            {
                Spawn();
            }

        }
        /*else if (gestureIndex != 0 && gesture == requiredGestures[0])
        {
            gestureIndex = 0;
        }*/
        else
        {

        }

    }

    void Spawn()
    {

        gestureIndex= 0;
        RaycastHit hit;
        Vector3 lookedAtPos;
        Vector3 spawnPos = playerHead.transform.forward;

        if (Physics.Raycast(playerHead.transform.position, playerHead.transform.forward, out hit, viewRange))
        {
            Debug.Log("Raycast hit look");
            lookedAtPos = hit.point;
        }
        else
        {
            Debug.Log("Raycast missed look");
            lookedAtPos = playerHead.transform.position + playerHead.transform.forward * viewRange;

        }


        //Debug.DrawLine(playerHead.transform.position, lookedAtPos, Color.red, 20f);
        if (IsSpawnPositionTooClose(lookedAtPos))   { Debug.Log("Failed to summon rock, too close to player"); return; }
        
        if (Physics.Raycast(lookedAtPos, Vector3.down, out hit, maxFloorDistance, rockSpawnLayers))
        {
            Instantiate(objectToSpawn, playerHead.transform.position + new Vector3(spawnPos.x , hit.point.y, spawnPos.z) * viewRange, Quaternion.identity);

            Debug.Log("Rock Summoned");
            
        }
        else
        {
            
            Debug.Log("Failed to summon");
        }
        //Debug.DrawLine(hit.point + Vector3.down * maxFloorDistance, lookedAtPos, Color.green, 20f);

        StartCooldown();


    }
    /// <summary>
    /// Checks if the position that the prefab wants to be instantiated at is too close to the player.
    /// </summary>
    /// <returns></returns>
    bool IsSpawnPositionTooClose(Vector3 spawnPosition)
    {
        spawnPosition = new Vector3(spawnPosition.x, 0, spawnPosition.z);
        Vector3 playerPosition = new Vector3(playerHead.transform.position.x, 0, playerHead.transform.position.z);

        return Vector3.Distance(spawnPosition, playerPosition) < tooCloseDistance;
    }

    
}
