using System.Collections;
using System.Collections.Generic;
using TakeArms.Services;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private GameObject _cardVisual;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (GameSystemService.GameUISystem.CardSelection.SelectedCard?.gameObject != _cardVisual)
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
            GameSystemService.GameUISystem.CardSelection.InspectCard(_cardVisual);
        }
       
    }
}
