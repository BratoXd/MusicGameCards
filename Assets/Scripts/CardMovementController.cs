using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class CardMovementController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform returnToParent = null;
    public Image imageCard;

    private void Start() {
        Sprite[] sprites = Resources.LoadAll<Sprite>("CharacterImages");
          //Sprite[] sprites =   Resources.FindObjectsOfTypeAll<Sprite>();
            imageCard.sprite = sprites[Random.RandomRange(0,sprites.Length)];

    }
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
