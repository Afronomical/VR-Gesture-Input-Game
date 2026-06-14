using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_GlossMapScale")]
    struct GlossMapScaleFloatOverride : IComponentData
    {
        public float Value;
    }
}
