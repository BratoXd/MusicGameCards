using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public int applausePoints; // Puntos de aplausos del jugador
    public GlobalStats globalStats; // Energía del jugador
    bool turnOver; // Indica si el turno del jugador ha terminado

    public TextMeshProUGUI clapsLabel;
    public TextMeshProUGUI energyLabel;
    public CardGenerator cardGenerator;
    public Button buttonChangeTurn;
        public Button buttonAttack;

    public GameObject HandPanel;

     private void Awake() {
        // Inicializa el jugador
        globalStats.AplausosGlobalStat = 20;
        globalStats.EnergiaGlobalStat = 10; // Asume que los jugadores comienzan con 10 de energía
        turnOver = false;    
    }
    void Start()
    {
    
    }

    public void turnOverFalse()
    {
        // Inicia el turno del jugador
        turnOver = false;
    }

    public void TurnOverTrue()
    {
        // Indica que el turno del jugador ha terminado
        turnOver = true;
    }
    public bool IsTurnOver()
    {
        // Devuelve si el turno del jugador ha terminado
        return turnOver;
    }


    public void RechargeEnergy()
    {
        // Recarga la energía del jugador
        globalStats.EnergiaGlobalStat = globalStats.EnergiaGlobalStat + 10; // Asume que los jugadores recargan hasta 10 de energía
        setText_TMP();
    }

    public void setText_TMP()
    {
        energyLabel.text = "Energía: " + globalStats.EnergiaGlobalStat.ToString();
        clapsLabel.text = "Aplausos: " + globalStats.AplausosGlobalStat.ToString();
    }

    public void DrawCards()
    {
        cardGenerator.Generator(5);
        validateEnergyCard();
    }

    public void validateEnergyCard()
    {
        if (globalStats.EnergiaGlobalStat > 0)
        {
            //    GameObject[] gameObjects = GetComponentsInChildren<GameObject>();


            var cards = cardGenerator.GetComponentsInChildren<CardMovementController>();
            foreach (CardMovementController card in cards)
            {
                if (card.dataCard.Costo > globalStats.EnergiaGlobalStat)
                {
                    card.GetComponent<CanvasGroup>().blocksRaycasts = false;
                    //card.gameObject.SetActive(false);
                }
                else
                {
                    card.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    //card.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            foreach (CardMovementController card in cardGenerator.GetComponentsInChildren<CardMovementController>())
            {
                card.GetComponent<CanvasGroup>().blocksRaycasts = false;
                //card.gameObject.SetActive(false);
            }
        }
    }

    public void DoubleApplausePoints()
    {
        // Duplica los puntos de aplausos del jugador
        globalStats.AplausosGlobalStat *= 2;
    }

    public int GetApplausePoints()
    {
        // Devuelve los puntos de aplausos del jugador
        return globalStats.AplausosGlobalStat;
    }



}
