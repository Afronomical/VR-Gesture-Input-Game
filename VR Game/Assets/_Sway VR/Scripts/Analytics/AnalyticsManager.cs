using UnityEngine;
using Unity.Services;
public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance;
    private bool isInitialized = false;

    private void Awake()
    {
        if(Instance!= null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance= this;
        }
    }


    private async void Start()
    {
       // await Unity.Services.AnalyticsManager.Start();
    }
}
