using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField]
    int MapSizeX = 64;

    [SerializeField]
    int MapSizeY = 64;

    [SerializeField]
    int MaxRoom = 10;

    [SerializeField]
    GameObject floorPrefab;

    private int[,] map;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        map = new MapGenerator().GenerateMap(MapSizeX, MapSizeY, MaxRoom);

        var floorList = new List<Vector3>();

        for (int y = 0; y < MapSizeY; y++)
        {
            for (int x = 0; x < MapSizeX; x++)
            {
                if (map[x, y] == 1)
                {
                    Instantiate(floorPrefab, new Vector3(x, 0, y), new Quaternion());
                }
            }
        }
    }
}
