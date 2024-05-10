using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DropZone : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{

  public GlobalStats globalStats;

  public void OnDrop(PointerEventData eventData)
  {
    CardMovementController card = eventData.pointerDrag.GetComponent<CardMovementController>();
    globalStats.EnsambleGlobalStat =  globalStats.EnsambleGlobalStat+ card.dataCard.DireccionScore;
    globalStats.EnsambleGlobalStat_TMP.text = "Poder de Ensable: " + globalStats.EnsambleGlobalStat.ToString();

   globalStats.RitmoGlobalStat = globalStats.RitmoGlobalStat + card.dataCard.RitmoScore;
   globalStats.RitmoGlobalStat_TMP.text = "Poder Ritmico: " + globalStats.RitmoGlobalStat.ToString();

    globalStats.ArmoniasGlobalStat = globalStats.ArmoniasGlobalStat + card.dataCard.ArmoniaScore;
    globalStats.ArmoniasGlobalStat_TMP.text = "Poder Armonico: " + globalStats.ArmoniasGlobalStat.ToString();

    globalStats.MelodiasGlobalStat = globalStats.MelodiasGlobalStat + card.dataCard.MelodiaScore; 
    globalStats.MelodiasGlobalStat_TMP.text = "Poder Melodico: " + globalStats.MelodiasGlobalStat.ToString();
  }

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
