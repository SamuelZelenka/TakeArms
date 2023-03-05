using TakeArms.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using TakeArms.Configurations;

namespace TakeArms.Actions
{
    public class ActionCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private GameObject _rootObject;
        private SpriteRenderer _cardBackground;
        private TMP_Text _cardName;
        private TMP_Text _description;
        private ActionCardConfiguration _config;

        public void SetCard(ActionCardConfiguration config)
        {
            _cardBackground.sprite = config.CardSprite;
            _cardName.text = config.CardName;
            _description.text = config.Description;
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (GameSystemService.GameUISystem.CardSelection.SelectedCard?.gameObject != _rootObject)
            {
                transform.localScale *= 1.2f;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = Vector3.one;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == 0)
            {
                GameSystemService.GameUISystem.CardSelection.InspectCard(_rootObject);
            }
        }
    }
}

