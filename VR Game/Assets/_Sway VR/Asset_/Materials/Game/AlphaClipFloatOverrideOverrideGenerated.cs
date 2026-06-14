using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_AlphaClip")]
    struct AlphaClipFloatOverride : IComponentData
    {
        public float Value;
    }
}
