using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [SerializeField] private CharacterList _charecterList;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Image _characterIcon;
    [SerializeField] private TMP_Text _characterNameText;
    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private GameObject _costObject;

    [Header("Buttons")]
    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _buyButton;

    private Character _currentCharacter;
    private int _cost;


    public void SetCharecter(Character character)
    {
        _currentCharacter = character;
        _characterIcon.sprite = _currentCharacter.SpriteCharecter;
        _characterNameText.text = _currentCharacter.Name;
        string damage = _currentCharacter.IWeapon.Damage.ToString();
        _damageText.text = damage;
        _speedText.text = character.PlayerModel.MoveSpeed.ToString();
        _healthText.text = character.PlayerModel.MaxHealth.ToString();
        _costText.text = character.Cost.ToString();
        _cost = character.Cost;

        if (_currentCharacter.IsPurchased)
        {
            _costObject.gameObject.SetActive(false);
            _selectButton.gameObject.SetActive(true);
            _buyButton.gameObject.SetActive(false);
        }
        else
        {
            _costObject.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(true);
        }
    }

    public void BuyCharacter()
    {
        if(_wallet.Coins >= _cost)
        {
            _wallet.DecreseCoins(_cost);
            _currentCharacter.SetIsPurchasedFlag(true);
            _costObject.gameObject.SetActive(false);
            _selectButton.gameObject.SetActive(true);
            _buyButton.gameObject.SetActive(false);
            SavePurchasedCharecters();
        }
    }


    private void SavePurchasedCharecters()
    {
        string ids = "";
        int id = 0;
        foreach(var item in _charecterList.Characters)
        {
            if (item.IsPurchased)
                ids += id.ToString() + "/";

            id++;
        }

        PlayerPrefs.SetString("Charecters", ids);
    }

}
