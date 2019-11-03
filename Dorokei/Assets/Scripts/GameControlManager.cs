using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlManager : MonoBehaviour
{
    // public
    [Header("ゲームタイマー")]
    public float GameTimer;
    [Header("入力用ゲームタイマー")]
    public float InputGameTimer;

    [Header("入力回数")]
    public int GameInputCounter;

    [Header("入力の時間")]
    [SerializeField]
    public float InputSpan = 2.0f;

    // 泥棒、警察
    public GameObject ObjTheif;
    public GameObject ObjPolice1;
    public GameObject ObjPolice2;

    // フィールドデータ用
    public field FieldData;
    int StageNo;
    float TotalTileLength;

    // Start is called before the first frame update
    void Start()
    {
        GameTimer = 0.0f;
        InputGameTimer = 0.0f;
        GameInputCounter = 0;
        StageNo = 0;
        TotalTileLength = FieldData.TileLength * FieldData.StageTileMax[StageNo];


        Vector3 posTheif = new Vector3(3, 0, 0);
        Vector3 posPolice1 = new Vector3(2, 0, 0);
        Vector3 posPolice2 = new Vector3(1, 0, 0);

        // 床並べる
        for (int i = 0; i < FieldData.TileMax; ++i)
        {
            for (int j = 0; j < FieldData.TileMax; ++j)
            {
                int data = FieldData.StageData[StageNo, i, j];
                if( data == 1)
                {
                    posTheif = new Vector3(j * FieldData.TileLength - TotalTileLength / 2.0f,
                            0.0f,
                            i * (-1.0f) * FieldData.TileLength + TotalTileLength / 2.0f);
                }else if( data == 2)
                {
                    posPolice1 = new Vector3(j * FieldData.TileLength - TotalTileLength / 2.0f,
                            0.0f,
                            i * (-1.0f) * FieldData.TileLength + TotalTileLength / 2.0f);
                }else if( data == 3)
                {
                    posPolice2 = new Vector3(j * FieldData.TileLength - TotalTileLength / 2.0f,
                            0.0f,
                            i * (-1.0f) * FieldData.TileLength + TotalTileLength / 2.0f);
                }
            }
        }

        Instantiate(ObjTheif, posTheif, Quaternion.identity);
        Instantiate(ObjPolice1, posPolice1, Quaternion.identity);
        Instantiate(ObjPolice2, posPolice2, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // count timer
        float preInputTimer = InputGameTimer;
        GameTimer += Time.deltaTime;
        InputGameTimer += Time.deltaTime;
        // input counter
        if(InputGameTimer > InputSpan )
        {
            InputGameTimer -= InputSpan;
            GameInputCounter++;
        }
    }
}
