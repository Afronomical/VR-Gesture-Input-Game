using UnityEditor;
using UnityEditor.Recorder;

using UnityEngine;

public class SceneViewLocator : MonoBehaviour
{
    public Camera sceneCam;
    public Transform targetTransform;
    public SceneView sceneView;
    RecorderWindow recorder;

    private void Start()
    {
        sceneView = EditorWindow.GetWindow<SceneView>();
        sceneCam = sceneView.camera;
        recorder = EditorWindow.GetWindow<RecorderWindow>();
        
    }
    private void Update()
    {
        transform.position = sceneCam.transform.position;
        transform.rotation = sceneCam.transform.rotation;

        if (targetTransform == null) { return; }

        sceneCam.transform.position = targetTransform.position;
    }
}
