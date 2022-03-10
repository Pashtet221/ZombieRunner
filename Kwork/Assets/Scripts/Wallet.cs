using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wallet : MonoBehaviour
{
    [SerializeField] private UI _uI;
    private int _coins;

    public int Coins => _coins;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            _coins = PlayerPrefs.GetInt("Coins");
        }
        _uI.UpdateCoins(_coins);
    }

    public void IncreseCoins(int count)
    {
        _coins += count;
        PlayerPrefs.SetInt("Coins", _coins);
        _uI.UpdateCoins(_coins);
    }

    public void DecreseCoins(int count)
    {
        _coins -= count;
        PlayerPrefs.SetInt("Coins", _coins);
        _uI.UpdateCoins(_coins);
    }

}
