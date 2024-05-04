using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CardMovementController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform returnToParent = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("comiezo a dragear");
        returnToParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
 
        this.transform.position = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Termindo de  dragear");
        this.transform.SetParent(returnToParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    // Start is called before the first frame update
 

}
