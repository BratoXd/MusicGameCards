using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CardMovementController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("comiezo a dragear");
    }


    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drageaando ando");
    this.transform.position = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Termindo de  dragear");

    }
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("empezo este jaler");
    }

    // Update is called once per frame
    void Update()
    {

    }


}
