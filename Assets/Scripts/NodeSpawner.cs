using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NodeSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public Node nodo;
    void Start()
    {
        spawnearNodos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnearNodos()
    {
        BoundsInt bounds= tilemap.cellBounds;
        for (int i = bounds.xMin; i < bounds.xMax; i+=5)
        {
            for (int j = bounds.yMin; j < bounds.yMax; j+=5)
            {
                Instantiate(nodo, new Vector3(i, j, 0f), transform.rotation);
            }
        }

    }

}
