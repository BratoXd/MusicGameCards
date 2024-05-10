using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int applausePoints; // Puntos de aplausos del jugador
    int energy; // Energía del jugador
    bool turnOver; // Indica si el turno del jugador ha terminado

    public TextMeshProUGUI clapsLabel;
    public TextMeshProUGUI energyLabel;
    public    CardGenerator cardGenerator;
    public Button buttonChangeTurn;
    void Start()
    {
        // Inicializa el jugador
        applausePoints = 20;
        energy = 10; // Asume que los jugadores comienzan con 10 de energía
        turnOver = false;
    }

  public  void startTurn()
    {
        // Inicia el turno del jugador
        turnOver = false;
    }
       
    public void EndTurn()
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
        energy = energy + 10; // Asume que los jugadores recargan hasta 10 de energía
         setText_TMP();
    }

    public void setText_TMP()
    {
        energyLabel.text = "Energía: "  + energy.ToString();
        clapsLabel.text = "Aplausos: " + applausePoints.ToString();
    }

    public void DrawCards()
    {
        cardGenerator.Generator(5);
    }

    public void DoubleApplausePoints()
    {
        // Duplica los puntos de aplausos del jugador
        applausePoints *= 2;
    }

    public int GetApplausePoints()
    {
        // Devuelve los puntos de aplausos del jugador
        return applausePoints;
    }



}
