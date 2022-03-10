using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInterfaceView : MonoBehaviour , IPlayerInterfaceView
{

    [SerializeField] private TMP_Text healthCountText;
    [SerializeField] private TMP_Text bulletCountText;
    [SerializeField] private TMP_Text moveCountText;


    [SerializeField] private Image healthIndicator;

    public void HealthChange(int health)
    {
    }

    public void MakeMoveCount(int moveCount)
    {
        moveCountText.text = "Метров: " + moveCount.ToString();
    }

    public void Move()
    {
    }

    public void Shoot()
    {
    }
}
