using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CreateWaterBall_Ability : Ability
{
    //[SerializeField] ParticleSystem _SplashPrefab;
    //[SerializeField] ParticleSystem _SpillPrefab;
    [SerializeField] ParticleSystem _WaterBallParticleSystem;
    //private Vector3 splashPosition;
    //public Vector3 moveDirection;

    [SerializeField] GameObject waterBallPrefab;


    /*void Splash(Vector3 direction)
    {
        _WaterBallParticleSystem.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        ParticleSystem splas = Instantiate(_SplashPrefab, splashPosition, Quaternion.identity);
    }*/
    [Tooltip("The furthest away the player can look to spawn a rock")]
    [SerializeField] private float viewRange = 5f;
    [Tooltip("If the distance between the player and a rock's spawn position is less than this value, \n it will not spawn")]
    [SerializeField] private float tooCloseDistance = 2f;
    [Tooltip("The furthest distance downwards that a rock can spawn from the point the player is looking at")]
    [SerializeField] private float maxFloorDistance = 2f;

    [Tooltip("Rocks will only spawn above this layer")]
    public LayerMask rockSpawnLayers;

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
    }

    void Spawn()
    {

        gestureIndex = 0;
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
        if (IsSpawnPositionTooClose(lookedAtPos)) { Debug.Log("Failed to summon rock, too close to player"); return; }

        if (Physics.Raycast(lookedAtPos, Vector3.down, out hit, maxFloorDistance, rockSpawnLayers))
        {
            Instantiate(waterBallPrefab, playerHead.transform.position + new Vector3(spawnPos.x, 0, spawnPos.z) * viewRange, Quaternion.identity);

            Debug.Log("Water Summoned");

        }
        else
        {
            Instantiate(waterBallPrefab, playerHead.transform.position + new Vector3(spawnPos.x, 0, spawnPos.z) * viewRange, Quaternion.identity);

            Debug.Log("Failed to summon");
        }
        //Debug.DrawLine(hit.point + Vector3.down * maxFloorDistance, lookedAtPos, Color.green, 20f);

        StartCooldown();
    }
    bool IsSpawnPositionTooClose(Vector3 spawnPosition)
    {
        spawnPosition = new Vector3(spawnPosition.x, 0, spawnPosition.z);
        Vector3 playerPosition = new Vector3(playerHead.transform.position.x, 0, playerHead.transform.position.z);

        return Vector3.Distance(spawnPosition, playerPosition) < tooCloseDistance;
    }
}
