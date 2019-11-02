using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    [Header("床の数")]
    [SerializeField]
    int TileMax = 19;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/Tile");

        for(int i=0; i<TileMax;++i)
        {
            for(int j=0; j<TileMax; ++j)
            {
                Instantiate(obj, new Vector3(i * 1.0f, 0.0f, j * (-1.0f)), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}