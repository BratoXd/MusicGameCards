using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DropZone : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
  public void OnDrop(PointerEventData eventData) { }

  public void OnPointerClick(PointerEventData eventData) { }

  public void OnPointerExit(PointerEventData eventData)
  {


  }

  public void OnPointerEnter(PointerEventData eventData)
  {

    if (eventData.pointerDrag != null)
    {
      Debug.Log(eventData.pointerDrag.name + " se bajo la carata en " + this.name);
      CardMovementController card = eventData.pointerDrag.GetComponent<CardMovementController>();
      card.returnToParent = this.transform;
    }
  }


}
