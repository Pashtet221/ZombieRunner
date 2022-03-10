using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private PlayerPresenter playerPresenter;
    [SerializeField] private PlayerModel playerModel;
    [SerializeField] private PlayerCharacterView playerCharacterView;
    [SerializeField] private PlayerInterfaceView playerInterfaceView;
    [SerializeField] private Character baseCharater;
    
    private void Start()
    {
        playerPresenter.PresenterConstructor(playerModel, playerInterfaceView, playerCharacterView);
        playerPresenter.SetCharacter(baseCharater);
    }

    public void Play()
    {
        gameState.SetGameState(StateGame.GAME);
    }


}
