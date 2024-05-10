using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    int TotalRounds = 3;
    public int turnCount = 0; // Contador de turnos
    public int roundCount = 0; // Contador de rondas
    public Player currentPlayer; // Jugador actual
    public List<Player> players; // Lista de jugadores
    public TextMeshProUGUI[] CurrentRound_TMP;
    void Start()
    {
        // Inicializa el juego
        currentPlayer = players[0]; // El primer jugador comienza
        startTurn();
    }

    void startTurn()
    {
        //  currentPlayer.buttonChangeTurn.interactable = true;
        currentPlayer.turnOverFalse();
        currentPlayer.RechargeEnergy();
        currentPlayer.DrawCards();
        currentPlayer.buttonChangeTurn.interactable = true;
    }

    void Update()
    {
        // Comprueba si el jugador actual ha terminado su turno
        if (currentPlayer.IsTurnOver())
        {
            EndTurn();
        }
    }

    void disableCurrentPlayerCards()
    {
        currentPlayer.buttonChangeTurn.interactable = false;
        CardMovementController[] allplayercards = currentPlayer.GetComponentsInChildren<CardMovementController>();
        foreach (CardMovementController card in allplayercards)
        {
            card.enabled = false;
        }
    }
    void EndTurn()
    {
        disableCurrentPlayerCards();

        // Actualiza el contador de turnos y cambia al siguiente jugador
        turnCount++;

        currentPlayer.turnOverFalse();
        // Comprueba si se ha completado una ronda
        if (turnCount % players.Count == 0)
        {
            EndRound();
        }
        if (roundCount < TotalRounds)
        {
            currentPlayer = players[turnCount % players.Count];
            startTurn();
        }

    }

    void refreshCurrentRoundText()
    {
        foreach (var CurrentRoundLabel in CurrentRound_TMP)
        {
            CurrentRoundLabel.text = "Ronda Actual: " + roundCount.ToString();
        }
    }


    void EndRound()
    {
        // Actualiza el contador de rondas
        roundCount++;
        refreshCurrentRoundText();
        // Si es la última ronda, los puntos de aplausos valen doble
        if (roundCount == TotalRounds) // Asume que hay 10 rondas en un juego
        {
            foreach (Player player in players)
            {
                player.DoubleApplausePoints();
            }
            calculateApplausePoints();
        }
        // Comprueba las condiciones de victoria y derrota
        foreach (Player player in players)
        {
            if (player.GetApplausePoints() >= 60)
            {
                Debug.Log(player.name + " ha ganado el juego!");
                // Termina el juego y celebra la victoria del jugador
            }
            else if (player.GetApplausePoints() <= 0)
            {
                Debug.Log(player.name + " ha perdido el juego.");
                // Termina el juego y maneja la derrota del jugador
            }

        }

    }

    void calculateApplausePoints()
    {
        foreach (Player player in players)
        {
            Debug.Log(player.name + " ha obtenido " + player.GetApplausePoints() + " puntos de aplausos.");
        }
        currentPlayer.setText_TMP();
        showWinnerLabel();
        finaldisabledPlayerCards();
    }

    void finaldisabledPlayerCards()
    {
        foreach (Player player in players)
        {
            player.buttonChangeTurn.interactable = false;
            CardMovementController[] allplayercards = player.GetComponentsInChildren<CardMovementController>();
            foreach (CardMovementController card in allplayercards)
            {
                card.enabled = false;
            }
        }
    }

    void showWinnerLabel()
    {

        WinnerLabel.text = "El ganador es: " + currentPlayer.name;
        WinnerLabel.gameObject.SetActive(true);

        // Muestra la etiqueta del ganador
    }

    public TextMeshProUGUI WinnerLabel;

}
