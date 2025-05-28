using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Hero.Behaviours
{
    public class HPMeter : MonoBehaviour
    {
        public Slider ProgressBar;
        public Image Fill;

        public void SetHP(float heroHealth, float fullHealth)
        {
            ProgressBar.value = heroHealth / fullHealth;
        }
    }
}