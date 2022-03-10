using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;


    public void SendLeaderBoard(int score)
    {

    }

    private void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {

    }

    public void GetLeaderBoard()
    {

    }

    private void OnLeaderBoardGet(GetLeaderBoardResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.LeaderBoard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();
        };
    }
}
