using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DropZone : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData) { }

    public void OnPointerClick(PointerEventData eventData) { }

    public void OnPointerExit(PointerEventData eventData)
    {
       Debug.Log(eventData.pointerDrag.name + " se bajo la carata en ");
       // CardMovementController d = eventData.pointerDrag.GetComponent<CardMovementController>();
      //  d.returnToParent = this.transform;

    }

}
