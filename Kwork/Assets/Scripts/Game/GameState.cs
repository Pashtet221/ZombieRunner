using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateGame { PAUSE, GAME , SHOP , MENU}

public class GameState : MonoBehaviour
{
    public static StateGame StateGame { get; private set; } = StateGame.PAUSE;


    public void SetGameState(StateGame stateGame)
    {
        StateGame = stateGame;
    }


}
