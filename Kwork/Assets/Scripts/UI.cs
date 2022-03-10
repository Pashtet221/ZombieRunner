using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameInit _gameInit;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _menu;


    public void UpdateCoins(int coins)
    {
        _coins.text = coins.ToString();
    }

    public void OpenMenu()
    {
        _gameState.SetGameState(StateGame.MENU);
        _menu.SetActive(true);
        _shop.SetActive(false);
    }

    public void StartGame()
    {
        _gameInit.Play();
        _shop.SetActive(false);
        _menu.SetActive(false);
    }

    public void OpenShop()
    {
        _gameState.SetGameState(StateGame.SHOP);
        _shop.SetActive(true);
        _menu.SetActive(false);
    }
}
