using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapPartGenerator : MonoBehaviour
{
    [SerializeField] private MapPart mapPartPrefab;
    [SerializeField] private Map map;
    [SerializeField] private MapObjectList mapObjectList;
    [SerializeField] private MapSettings mapSettings;
    [SerializeField] private EnemySpawner enemySpawner;

    public event System.Action OnMapGenerated;

    private RandomDrop randomDrop;


    private void Start()
    {
        randomDrop = new RandomDrop(mapObjectList.MapObjectsParam.ToArray());
        MapPart mapPart = CreateMapPart();
        mapPart.InitMap();
        SetMapPartOnPosition(mapPart);
        FillMapPartWithObjects(mapPart);
        map.AddMapPart(mapPart);

        GenerateMapPart();

        OnMapGenerated?.Invoke();
    }

    public MapPart GenerateMapPart()
    {
        MapPart mapPart = CreateMapPart();
        mapPart.InitMap();
        SetMapPartOnPosition(mapPart);
        FillMapPartWithEnemys(mapPart);
        FillMapPartWithObjects(mapPart);
        map.AddMapPart(mapPart);
        return mapPart;
    }

    private void FillMapPartWithObjects(MapPart mapPart)
    {
        int targetObjectsCount = Random.Range(mapSettings.MinObjects, mapSettings.MaxObjects);

        for(int i = 0; i < targetObjectsCount; i++)
        {
            GameObject gameObject = (GameObject)randomDrop.GetRandomDrop();
            CreateObject(gameObject, mapPart, 0.3f);
        }
    }

    private void FillMapPartWithEnemys(MapPart mapPart)
    {
        int targetObjectsCount = Random.Range(mapSettings.MinEnemys, mapSettings.MaxEnemys);

        Enemy[] enemies = enemySpawner.CreateEnemys(targetObjectsCount);
        foreach(var enemy in enemies)
        {
            TrySetObjectOnMapPart(enemy, mapPart, 8f);
        }
    }

    private void CreateObject(GameObject gameObject , MapPart mapPart, float size)
    {
        if (TryCreateObjectByIndex(gameObject, out IMapObject mapObject, mapPart))
        {
            if (TrySetObjectOnMapPart(mapObject, mapPart, size))
            {
                mapPart.AddObjectOnMap(mapObject);
            }
        }
    }

    private bool TrySetObjectOnMapPart(IMapObject mapObject, MapPart mapPart, float size)
    {
        for(int i = 0; i < 5; i++)
        {
            float xRandom = Random.Range(mapPart.MinBounds.x + 3, mapPart.MaxBounds.x - 3);
            float yRandom = Random.Range(mapPart.MinBounds.y + 3, mapPart.MaxBounds.y - 3);

            mapObject.Object.transform.position = new Vector2(xRandom, yRandom);
            mapObject.Object.transform.localScale = new Vector2(size, size);
            return true;

            //if (!mapPart.CheckObjectOnPosition(new Vector2Int(xRandom, yRandom)))
            //{
            //}

        }
        return false;
    }

    private bool TryCreateObjectByIndex(GameObject gameObject , out IMapObject spawnedObject , MapPart mapPart)
    {
        GameObject objectToSpawn = gameObject;
        if(objectToSpawn.TryGetComponent(out IMapObject mapObject))
        {
            spawnedObject = Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity, mapPart.transform).GetComponent<IMapObject>();
            return true;
        }
        spawnedObject = default;
        return false;
    }

    private void SetMapPartOnPosition(MapPart mapPart)
    {
        Vector3 lastMapPartPosition = map.GetLastMapPartPosition();
        mapPart.transform.position = new Vector3(mapPart.Widht + lastMapPartPosition.x, lastMapPartPosition.y, lastMapPartPosition.z);
    }

    private MapPart CreateMapPart()
    {
        return Instantiate(mapPartPrefab);
    }

}
