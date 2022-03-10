using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private IWeapon currentWeapon;
    private GameObject weapon;

    public IWeapon CurrentWeapon => currentWeapon;

    public void SetCurrentWeapon(GameObject weapon)
    {
        if (!weapon.TryGetComponent(out IWeapon iWeapon)) return;

        if (this.weapon != null)
            Destroy(this.weapon);


        this.weapon = Instantiate(weapon, transform.position, Quaternion.identity);
        this.weapon.transform.SetParent(player);
        currentWeapon = this.weapon.GetComponent(typeof(IWeapon)) as IWeapon;
        currentWeapon.AttackFromPoint = player;
    }

    public void Attack(Enemy enemyTarget)
    {
        if(currentWeapon != null)
            currentWeapon.Attack(enemyTarget);
    }
}
