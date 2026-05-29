using UnityEngine;

public class ScaleToCamera : MonoBehaviour
{
    Camera cam;
    Vector3 scaleUpValue;
    float distance;
    [Tooltip("Adjust the perceived scale of the object at range, \n I've found 1 works best for my WorldSpace UI")]
    [SerializeField]float scaleOffset = 1;

    private void Start()
    {
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        UpdateScale();
    }
    void UpdateScale()
    {
        distance = Vector3.Distance(transform.position, cam.transform.position);
        scaleUpValue.x = distance / scaleOffset;
        scaleUpValue.y = distance / scaleOffset;
        scaleUpValue.z = distance / scaleOffset;

        transform.localScale = scaleUpValue;
    }
}
