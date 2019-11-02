using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    [Header("床の数")]
    [SerializeField]
    int TileMax = 19;

    [Header("床の数")]
    [SerializeField]
    float TileLength = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/Tile");
        float TotalTileLength = TileLength * TileMax;

        // 床並べる
        for(int i=0; i<TileMax;++i)
        {
            for(int j=0; j<TileMax; ++j)
            {
                Instantiate(obj, new Vector3(i * TileLength - TotalTileLength / 2.0f, 0.0f,
                    j * (-1.0f) * TileLength + TotalTileLength / 2.0f), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}