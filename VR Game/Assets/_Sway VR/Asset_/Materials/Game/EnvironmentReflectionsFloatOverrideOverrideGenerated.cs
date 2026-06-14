using Unity.Entities;
using Unity.Mathematics;

namespace Unity.Rendering
{
    [MaterialProperty("_EnvironmentReflections")]
    struct EnvironmentReflectionsFloatOverride : IComponentData
    {
        public float Value;
    }
}
