using System;
using System.Collections;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviours
{
    public class AbilityCard : MonoBehaviour
    {
        private const float StampAnimationTime = 1f;
        public AbilityId abilityId;
        public Image icon;
        public TextMeshProUGUI description;
        public Button button;
        public Action<AbilityId> _onSelected;

        public void Setup(AbilityId id, AbilityLevel abilityLevel, Action<AbilityId> onSelected)
        {
            abilityId = id;
            icon.sprite = abilityLevel.icon;
            description.text = abilityLevel.description;

            _onSelected = onSelected;
            
            button.onClick.AddListener(SelectCard);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(SelectCard);
        }

        private void SelectCard()
        {
            ApplyAbilityUpdate();
        }

        private void ApplyAbilityUpdate()
        {
            _onSelected?.Invoke(abilityId);
        }
    }
}