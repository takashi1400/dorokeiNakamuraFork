using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    [Header("床の数")]
    [SerializeField]
    public int TileMax = 19;

    [Header("床の長さ")]
    [SerializeField]
    public float TileLength = 1.0f;

    [Header("床の最大数")]
    [SerializeField]
    public int[] StageTileMax = {9, 13, 19};


    [Header("仮のステージデータ")]
    [SerializeField]
    public int[,,] StageData = new int[3, 19, 19]
    {
        {
            {1,4,4,4,4,6,4,4,4,0,0,0,0,0,0,0,0,0,0},
            {4,4,4,4,4,6,4,6,6,0,0,0,0,0,0,0,0,0,0},
            {4,4,4,4,4,6,4,6,7,0,0,0,0,0,0,0,0,0,0},
            {4,4,4,4,4,5,5,6,6,0,0,0,0,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,0,0},
            {6,6,6,5,4,6,6,6,4,0,0,0,0,0,0,0,0,0,0},
            {4,4,4,5,4,6,8,6,4,0,0,0,0,0,0,0,0,0,0},
            {4,6,6,6,4,6,6,6,2,0,0,0,0,0,0,0,0,0,0},
            {4,6,9,6,4,4,4,3,4,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        },
        {
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        },
        {
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
        },
    };

    public GameObject[] GameObjTresuresA;
    public GameObject[] GameObjTresuresB;
    public GameObject[] GameObjTresuresC;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ObjTile = (GameObject)Resources.Load("Prefabs/Tile");
        GameObject ObjBlock = (GameObject)Resources.Load("Prefabs/Obstacle");
        GameObject ObjLight = (GameObject)Resources.Load("Prefabs/Blight");
        GameObject ObjTresureA = (GameObject)Resources.Load("Prefabs/TREASURE_1");
        GameObject ObjTresureB = (GameObject)Resources.Load("Prefabs/TREASURE_2");
        GameObject ObjTresureC = (GameObject)Resources.Load("Prefabs/TREASURE_3");
        GameObject ObjWall = (GameObject)Resources.Load("Prefabs/WallAround");

        // ステージナンバー
        int StageNo = 0;

        float TotalTileLength = TileLength * StageTileMax[StageNo];


        // 床並べる
        for(int i=0; i<TileMax;++i)
        {
            for(int j=0; j<TileMax; ++j)
            {
                int data = StageData[StageNo, i, j];
                float heightAdjust = 0.0f;
                float xAdjust = 0.0f;
                float zAdjust = 0.0f;
                Debug.Log(data);
                if(data > 0)
                {
                    GameObject obj;
                    GameObject objTresure = null;
                    bool isTresure = false;
                    switch (data)
                    {
                        default:
                            obj = null;
                            objTresure = null;
                            break;
                        case 1:
                            obj = ObjTile;
                            break;
                        case 2:
                            obj = ObjTile;
                            break;
                        case 3:
                            obj = ObjTile;
                            break;
                        case 4:
                            obj = ObjTile;
                            break;
                        case 5:
                            obj = ObjBlock;
                            heightAdjust = 1.0f;
                            break;
                        case 6:
                            obj = ObjLight;
                            break;
                        case 7:
                            isTresure = true;
                            objTresure = ObjTresureA;
                            obj = ObjTile;
                            heightAdjust = 0.0f;
                            xAdjust = -0.0f;
                            zAdjust = -0.0f;
                            break;
                        case 8:
                            isTresure = true;
                            objTresure = ObjTresureB;
                            obj = ObjTile;
                            heightAdjust = 0.0f;
                            xAdjust = -0.0f;
                            zAdjust = -0.0f;
                            break;
                        case 9:
                            isTresure = true;
                            objTresure = ObjTresureC;
                            obj = ObjTile;
                            heightAdjust = 0.0f;
                            xAdjust = -0.0f;
                            zAdjust = -0.0f;
                            break;
                    }
                    Instantiate(obj, new Vector3(j * TileLength - TotalTileLength / 2.0f + xAdjust,
                        heightAdjust,
                        i * (-1.0f) * TileLength + TotalTileLength / 2.0f + zAdjust),
                        Quaternion.identity);
                    if( isTresure )
                    {
                        Instantiate(objTresure, new Vector3(j * TileLength - TotalTileLength / 2.0f + xAdjust,
                            1.0f,
                            i * (-1.0f) * TileLength + TotalTileLength / 2.0f + zAdjust),
                            Quaternion.identity);
                    }
                }
            }
        }

        // 壁並べる
        for(int i = 0; i<TileMax+2; ++i)
        {
            GameObject obj = ObjWall;

            for (int j = 0; j<TileMax+2; ++j)
            {
                bool view = false;
                if( i == 0
                    //|| i == StageTileMax[StageNo] + 1
                    )
                {
                    if(j <= StageTileMax[StageNo] + 1)
                    {
                        view = true;
                    }
                }
                if( j == 0 || j == StageTileMax[StageNo] + 1)
                {
                    if (i <= StageTileMax[StageNo])
                    {
                        view = true;

                    }
                }
                if(view)
                {
                    Instantiate(obj, new Vector3(j * TileLength - TotalTileLength / 2.0f - 1.0f, 1.0f,
                        i * (-1.0f) * TileLength + TotalTileLength / 2.0f + 1.0f), Quaternion.identity);
                }
            }
        }

        // 宝物置く

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}