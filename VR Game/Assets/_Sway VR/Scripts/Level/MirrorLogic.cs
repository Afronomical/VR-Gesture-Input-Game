using UnityEngine;
using UnityEngine.Video;

public class MirrorLogic : MonoBehaviour
{
    
    public bool isMirroring = false;
    public bool isInactiveVideo = false;
    public Camera cam;
    [SerializeField]private Material inactiveRenderingMaterial;
    [SerializeField]private Material activeRenderingMaterial;
    [SerializeField]private MeshRenderer screenToRenderTo;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        cam.forceIntoRenderTexture = false;

        Debug.Assert(cam.targetTexture != null, "Render Texture on Camera/Mirror returned null");

    }


    public void SetRenderTextureEnabled(bool isActive)
    {
        isMirroring = isActive;
         UpdateMirror();
    }

    void UpdateMirror()
    {
        if (isMirroring)
        {
            screenToRenderTo.material = activeRenderingMaterial;
        }
        else
        {
            
            if(!isInactiveVideo)
            {
                screenToRenderTo.material = inactiveRenderingMaterial;
            }
        }
        cam.gameObject.SetActive(isMirroring);
    }
}
