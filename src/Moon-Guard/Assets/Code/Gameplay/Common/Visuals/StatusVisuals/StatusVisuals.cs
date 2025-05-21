using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Common.Visuals.StatusVisuals
{
    public class StatusVisuals : MonoBehaviour, IStatusVisuals
    {
        private static readonly int ColorProperty = Shader.PropertyToID("_Color");
        private static readonly int ColorIntensityProperty = Shader.PropertyToID("_Intensity");
        private static readonly int OutlineSizeProperty = Shader.PropertyToID("_OutlineSize");
        private static readonly int OutlineColorProperty = Shader.PropertyToID("_OutlineColor");
        private static readonly int OutlineSmoothnessProperty = Shader.PropertyToID("_OutlineSmoothness");

        public Renderer Renderer;
        public Animator Animator;

        [Header("Freeze")] public Color FreezeColor = new Color32(56, 163, 190, 255);
        public float FreezeOutlineSize = 3;
        public float FreezeOutlineSmoothness = 8;
        public float FreezeColorIntensity = 0.6f;

        [Header("Poison")] public Color PoisonColor = new Color32(56, 163, 190, 255);
        public float PoisonColorIntensity = 0.6f;

        public void ApplyFreeze()
        {
            Renderer.material.SetColor(ColorProperty, FreezeColor);
            Renderer.material.SetFloat(ColorIntensityProperty, FreezeColorIntensity);
        }

        public void UnapplyFreeze()
        {
            Renderer.material.SetColor(OutlineColorProperty, Color.white);
            Renderer.material.SetFloat(OutlineSizeProperty, 0f);
            Renderer.material.SetFloat(OutlineSmoothnessProperty, 0f);
            if (Animator)
                Animator.speed = 1;
        }

        public void ApplyPoison()
        {
            Renderer.material.SetColor(ColorProperty, PoisonColor);
            Renderer.material.SetFloat(ColorIntensityProperty, PoisonColorIntensity);
        }

        public void UnapplyPoison()
        {
            Renderer.material.SetColor(ColorProperty, Color.white);
            Renderer.material.SetFloat(ColorIntensityProperty, 0f);
        }
    }
}