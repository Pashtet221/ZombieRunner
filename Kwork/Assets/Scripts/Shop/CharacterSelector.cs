using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private CharacterList _charecterList;
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private Shop _shop;
    private int _currentID;
    private Character _currentCharecter;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Charecters"))
        {
            string charecters = PlayerPrefs.GetString("Charecters");
            string[] ids = charecters.Split('/');
            foreach(var id in ids)
            {
                if(id != "")
                {
                    _charecterList.Characters[System.Convert.ToInt32(id)].SetIsPurchasedFlag(true);
                }
            }
        }
        else
        {
            _charecterList.Characters[0].SetIsPurchasedFlag(true);
            PlayerPrefs.SetString("Charecters", "0/");
        }
        _currentCharecter = _charecterList.Characters[0];
        _shop.SetCharecter(_currentCharecter);
    }

    public void Select()
    {
        _playerPresenter.SetCharacter(_currentCharecter);
    }

    public void NextCharecter()
    {
        if(_currentID + 1 < _charecterList.Characters.Count)
        {
            _currentID++;
            _currentCharecter = _charecterList.Characters[_currentID];
            _shop.SetCharecter(_currentCharecter);
        }
    }

    public void PreviousCharecter()
    {
        if (_currentID - 1 >= 0)
        {
            _currentID--;
            _currentCharecter = _charecterList.Characters[_currentID];
            _shop.SetCharecter(_currentCharecter);
        }
    }

}
