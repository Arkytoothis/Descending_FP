using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Descending
{
    public class CameraIgnoreFog : MonoBehaviour
    {
        void Start()
        {
            RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
            RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
        }
 
        void OnDestroy()
        {
            RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
            RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
        }
 
        void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
        {
            RenderSettings.fog = false;
        }
 
        void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
        {
            RenderSettings.fog = true;
        }
    }
}
