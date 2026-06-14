using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_Glossiness")]
    struct GlossinessFloatOverride : IComponentData
    {
        public float Value;
    }
}
