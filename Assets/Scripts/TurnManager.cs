using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int turnCount = 0; // Contador de turnos
    public int roundCount = 0; // Contador de rondas
    public Player currentPlayer; // Jugador actual
    public List<Player> players; // Lista de jugadores
    public TextMeshProUGUI CurrentRound;
    void Start()
    {
        // Inicializa el juego
        currentPlayer = players[0]; // El primer jugador comienza
        startTurn();
    }

    void startTurn ()
    {
        currentPlayer.buttonChangeTurn.interactable = true;
        currentPlayer.startTurn();
        currentPlayer.RechargeEnergy();
        currentPlayer.DrawCards();
    }

    void Update()
    {
        // Comprueba si el jugador actual ha terminado su turno
        if (currentPlayer.IsTurnOver())
        {
            EndTurn();
        }
    }

   
    void EndTurn()
    {        
        currentPlayer.buttonChangeTurn.interactable = false;

        // Actualiza el contador de turnos y cambia al siguiente jugador
        turnCount++;    
        currentPlayer = players[turnCount % players.Count];

        // Comprueba si se ha completado una ronda
        if (turnCount % players.Count == 0)
        {
            EndRound();
        }
    }


    void EndRound()
    {
        // Actualiza el contador de rondas
        roundCount++;
        CurrentRound.text = "Ronda Actual : " + roundCount;
        // Si es la última ronda, los puntos de aplausos valen doble
        if (roundCount == 10) // Asume que hay 10 rondas en un juego
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
    }
}
