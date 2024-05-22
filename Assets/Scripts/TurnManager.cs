using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{



    public TurnPhase currentPhase = TurnPhase.Draw; // Fase de turno actual

    public bool isAttackPhase = false; // Indica si es la fase de ataque
    public int attackPower = 0; // Poder de ataque del jugador actual  

    public int pointsToWin = 1000; // Puntos de aplausos necesarios para ganar
    int PointsToLose = 0; // Puntos de aplausos necesarios para perder
    public int TotalRounds = 3;
    public int turnCount = 0; // Contador de turnos
    public int roundCount = 0; // Contador de rondas
    public Player currentPlayer; // Jugador actual
    public List<Player> players; // Lista de jugadores
    public TextMeshProUGUI[] CurrentRound_TMP;

    public TextMeshProUGUI GrandFinaleLabel_TMP;

    private static TurnManager instance;
    public static TurnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TurnManager();

            }
            return instance;
        }
    }

    private TurnManager()
    {
        instance = this;
        // Constructor privado
    }


    public void StartAttackPhase()
    {
        currentPhase = TurnPhase.Attack;
        currentPlayer.buttonAttack.interactable = false;
        disableCardsHandPanel();
        enableCardsStations();
        // Aquí puedes añadir lógica para permitir al jugador seleccionar cartas de ataque y calcular el poder de ataque total
    }

    void EndAttackPhase()
    {
        isAttackPhase = false;
        // Aquí puedes añadir lógica para limpiar después de la fase de ataque, como desactivar cartas de ataque usadas
    }



    void enableCardsStations()
    {
        DropZone[] atackCardStatios = currentPlayer.GetComponentsInChildren<DropZone>();
        foreach (DropZone station in atackCardStatios)
        {
            if (station.Zone == zoneType.BattleZone)
            {
                var activatedCard = station.GetComponentInChildren<CardMovementController>();
                if (activatedCard != null)
                {
                    activatedCard.enabled = true;
                }
            }
        }



    }






    void Update()
    {
        // Comprueba si el jugador actual ha terminado su turno
        if (currentPlayer.IsTurnOver())
        {
            EndTurn();
        }
        else if (isAttackPhase)
        {
            // Aquí puedes añadir lógica para que el jugador realice acciones de ataque, como usar cartas de ataque
            // Por ejemplo, podrías verificar si el jugador ha seleccionado una carta de ataque y aplicar su efecto
        }

    }


    void Start()
    {
        currentPhase = TurnPhase.Draw;
        // Inicializa el juego
        currentPlayer = players[0]; // El primer jugador comienza
        startTurn();
    }

    void startTurn()
    {
        //  currentPlayer.buttonChangeTurn.interactable = true;
        waitlabelGrandFinale();
        currentPlayer.turnOverFalse();
        currentPlayer.RechargeEnergy();
        currentPlayer.DrawCards();
        currentPlayer.buttonChangeTurn.interactable = true;

    }



    void EndTurn()
    {
        currentPhase = TurnPhase.End;
        disableCurrentPlayerCards();

        // Actualiza el contador de turnos y cambia al siguiente jugador
        turnCount++;

        currentPlayer.turnOverFalse();
        // Comprueba si se ha completado una ronda
        if (turnCount % players.Count == 0)
        {
            EndRound();
        }
        if (roundCount < TotalRounds && !gameOver)
        {
            currentPlayer = players[turnCount % players.Count];
            startTurn();
        }
        currentPlayer.buttonAttack.interactable = true;
    }


    void disableCardsHandPanel()
    {
        CardMovementController[] cardsOnHand = currentPlayer.HandPanel.GetComponentsInChildren<CardMovementController>();
        foreach (CardMovementController card in cardsOnHand)
        {
            card.enabled = false;
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
    void refreshCurrentRoundText()
    {
        foreach (var CurrentRoundLabel in CurrentRound_TMP)
        {
            CurrentRoundLabel.text = "Ronda Actual: " + roundCount.ToString();
        }
    }

    void waitlabelGrandFinale()
    {
        GrandFinaleLabel_TMP.gameObject.SetActive(false);
    }
    void EndRound()
    {
        // Actualiza el contador de rondas
        roundCount++;
        refreshCurrentRoundText();
        if (roundCount == TotalRounds - 1)
        {
            ShowlastRoundLabel();
        }
        // Si es la última ronda, los puntos de aplausos valen doble
        if (roundCount == TotalRounds) // Asume que hay 10 rondas en un juego
        {
            GrandFinaleLabel_TMP.gameObject.SetActive(true);

            foreach (Player player in players)
            {
                player.DoubleApplausePoints();
            }
            calculateApplausePoints();
        }
        // Comprueba las condiciones de victoria y derrota
        foreach (Player player in players)
        {
            waitlabelGrandFinale();
            if (player.GetApplausePoints() >= pointsToWin)
            {

                Debug.Log(player.name + " ha ganado el juego!");
                calculateApplausePoints();
                gameOver = true;
                return;
                // Termina el juego y celebra la victoria del jugador
            }
            else if (player.GetApplausePoints() <= PointsToLose)
            {
                Debug.Log(player.name + " ha perdido el juego.");
                calculateApplausePoints();
                gameOver = true;
                return;
                // Termina el juego y maneja la derrota del jugador
            }

        }

    }

    void calculateApplausePoints()
    {
        foreach (Player player in players)
        {
            Debug.Log(player.name + " ha obtenido " + player.GetApplausePoints() + " puntos de aplausos.");
            player.setText_TMP();
        }


        showWinnerLabel();
        finaldisabledPlayerCards();
    }

    string calculatewinner()
    {
        Player winner = players[0];
        foreach (Player player in players)
        {
            if (player.GetApplausePoints() > winner.GetApplausePoints())
            {
                winner = player;
            }
        }
        return winner.name;
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
        WinnerLabel.text = "El ganador es: " + calculatewinner() + " con " + currentPlayer.GetApplausePoints() + " puntos de aplausos.";
        WinnerLabel.gameObject.SetActive(true);
    }


    void ShowlastRoundLabel()
    {
        GrandFinaleLabel_TMP.gameObject.SetActive(true);
    }

    bool gameOver = false;
    public TextMeshProUGUI WinnerLabel;

}
