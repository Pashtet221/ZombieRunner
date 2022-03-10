using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomDrop : MonoBehaviour
{
    private List<MapObjectParam> randomables = new List<MapObjectParam>();
    private List<int> randomIDs = new List<int>();
    private List<DropByID> drops = new List<DropByID>();
    public RandomDrop(MapObjectParam[] randomables)
    {
        this.randomables.AddRange(randomables);
        PrepareRandom();
    }

    public GameObject GetRandomDrop()
    {
        int randomNum = Random.Range(0, randomIDs.Count - 1);
        return drops[randomIDs[randomNum]].Drop;
  
    }

    private bool CheckIDInUsesIDs(int id)
    {
        if (drops.Count <= 0) return false;

        if (drops.FirstOrDefault(item => item.ID == id) != default)
            return true;

        return false;

    }

    private void PrepareRandom()
    {
        int id = 0;
        int exitIteration = 0;
        foreach(var item in randomables)
        {
            while (true)
            {
                id++;
                if (!CheckIDInUsesIDs(id))
                {
                    drops.Add(new DropByID() { ID = id, Drop = item.Object });
                    for(int i = 0; i < (int)item.SpawnFrequency / 10;i++)
                    {
                        randomIDs.Add(id);
                    }
                    exitIteration = 0;
                    break;
                }
                
                exitIteration++;

                if (exitIteration > 100)
                    break;
            }

        }
    }
}

public class DropByID
{
    public GameObject Drop;
    public int ID;
}