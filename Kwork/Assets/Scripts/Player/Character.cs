using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject _playerModel;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private Animator _animator;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _cost;
    [SerializeField] private string _name;
    private bool _isPurchased;

    public bool IsPurchased => _isPurchased;
    public GameObject ModelObject => _playerModel;
    public PlayerModel PlayerModel => _playerModel.GetComponent<PlayerModel>();
    public Animator Animator => _animator;
    public Sprite SpriteCharecter => _sprite;
    public GameObject Weapon => _weapon;
    public IWeapon IWeapon => _weapon.GetComponent(typeof(IWeapon)) as IWeapon;
    public int Cost => _cost;
    public string Name => _name;


    public void SetIsPurchasedFlag(bool flag)
    {
        _isPurchased = flag;
    }
}
