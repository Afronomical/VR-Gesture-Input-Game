using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_GlossyReflections")]
    struct GlossyReflectionsFloatOverride : IComponentData
    {
        public float Value;
    }
}
