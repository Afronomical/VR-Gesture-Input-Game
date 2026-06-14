using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_ReceiveShadows")]
    struct ReceiveShadowsFloatOverride : IComponentData
    {
        public float Value;
    }
}
