using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_SpecularHighlights")]
    struct SpecularHighlightsFloatOverride : IComponentData
    {
        public float Value;
    }
}
