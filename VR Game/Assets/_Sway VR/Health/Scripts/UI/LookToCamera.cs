using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        FaceTheCamera();
    }
    void FaceTheCamera()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
