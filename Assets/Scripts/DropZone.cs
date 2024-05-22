using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DropZone : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{

  public GlobalStats globalStats;

  public zoneType Zone;
  Player playerCard;
  Player playerZone;

  public void OnDrop(PointerEventData eventData)
  {

Debug.Log("OnDrop");
    CardMovementController card = eventData.pointerDrag.GetComponent<CardMovementController>();
    playerCard = card.GetComponentInParent<Player>();
    playerZone = this.GetComponentInParent<Player>();
    card.InitialZone = this.Zone;

    if (card.InitialZone == zoneType.Mano && this.Zone == zoneType.BattleZone)
    {
      globalStats.EnergiaGlobalStat = globalStats.EnergiaGlobalStat - card.dataCard.Costo;
      globalStats.EnergiaGlobalStat_TMP.text = "Energia: " + globalStats.EnergiaGlobalStat.ToString();

      globalStats.AplausosGlobalStat = globalStats.AplausosGlobalStat + card.dataCard.RitmoScore + card.dataCard.ArmoniaScore + card.dataCard.MelodiaScore;
      globalStats.AplausosGlobalStat_TMP.text = "Aplausos: " + globalStats.AplausosGlobalStat.ToString();


    }

    if (card.InitialZone == zoneType.BattleZone && this.Zone == zoneType.Mano)
    {
      globalStats.EnergiaGlobalStat = globalStats.EnergiaGlobalStat + card.dataCard.Costo;
      globalStats.EnergiaGlobalStat_TMP.text = "Energia: " + globalStats.EnergiaGlobalStat.ToString();

      globalStats.AplausosGlobalStat = globalStats.AplausosGlobalStat - card.dataCard.RitmoScore - card.dataCard.ArmoniaScore - card.dataCard.MelodiaScore;
      globalStats.AplausosGlobalStat_TMP.text = "Aplausos: " + globalStats.AplausosGlobalStat.ToString();

    }
    playerCard.validateEnergyCard();

    if (TurnManager.Instance.currentPhase == TurnPhase.Attack)
    {


      Debug.Log("Soy carta del jugador" + card.currentPlayer + " y estoy en la zona de batalla" + this.gameObject.name + " que pertenece al jugador" + playerZone);
      if (card.currentPlayer != playerZone)
      {
        CardMovementController cardZoneDefender = GetComponentInChildren<CardMovementController>();

        CalculateAndDesroy(card, cardZoneDefender);


      }
    }






  }

  void CalculateAndDesroy(CardMovementController card, CardMovementController cardZoneDefender)
  {
    if (card.dataCard.calculatePower() > cardZoneDefender.dataCard.calculatePower())
    {
      Destroy(cardZoneDefender.gameObject);
      //   returnCardAtackToInitPosition(card);
    }
 else if (card.dataCard.calculatePower() < cardZoneDefender.dataCard.calculatePower())
    {
      Destroy(card.gameObject);
    }
  }

  void returnCardAtackToInitPosition(CardMovementController card)
  {

    card.transform.SetParent(card.returnToParent);
  }




  public void OnPointerClick(PointerEventData eventData) { }

  public void OnPointerExit(PointerEventData eventData)
  {


  }

  public void OnPointerEnter(PointerEventData eventData)
  {

    if (eventData.pointerDrag != null)
    {
      if (TurnManager.Instance.currentPhase != TurnPhase.Attack)
      {
        Debug.Log(eventData.pointerDrag.name + " se bajo la carata en " + this.name);
        CardMovementController card = eventData.pointerDrag.GetComponent<CardMovementController>();

        card.NewParent = this.transform;

      }
    }
  }


}

