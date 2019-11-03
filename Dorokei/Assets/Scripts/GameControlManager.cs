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

    // 泥棒、警察 prefab
    public GameObject ObjTheif;
    public GameObject ObjPolice1;
    public GameObject ObjPolice2;

    // 泥棒、警察 本体
    GameObject GameObjTheif;
    GameObject GameObjPolice1;
    GameObject GameObjPolice2;

    // フィールドデータ用
    public GameObject ObjField;
    int StageNo;

    int TileMax;
    float TileLength;
    int[] StageTileMax;
    int StageTileNumMax;
    int[,,] StageData;
    float TotalTileLength;

    // 動く人クラス
    class PlayerBase
    {
        int x;
        int z;

        public int GetX()
        {
            return x;
        }
        public void SetX( int data)
        {
            x = data;
        }
        public int GetZ()
        {
            return z;
        }
        public void SetZ(int data)
        {
            z = data;
        }
    };

    // 泥棒
    PlayerBase Theif;
    PlayerBase Police1;
    PlayerBase Police2;


    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(ObjField, new Vector3(0,0,0), Quaternion.identity);
        Theif = new PlayerBase();
        Police1 = new PlayerBase();
        Police2 = new PlayerBase();

        GameTimer = 0.0f;
        InputGameTimer = 0.0f;
        GameInputCounter = 0;
        StageNo = 0;

        TileMax = ObjField.GetComponent<field>().TileMax;
        TileLength = ObjField.GetComponent<field>().TileLength;
        StageTileMax = ObjField.GetComponent<field>().StageTileMax;
        StageTileNumMax = StageTileMax[StageNo];
        StageData = ObjField.GetComponent<field>().StageData;

        TotalTileLength = TileLength * StageTileNumMax;


        Vector3 posTheif = new Vector3(3, 0, 0);
        Vector3 posPolice1 = new Vector3(2, 0, 0);
        Vector3 posPolice2 = new Vector3(1, 0, 0);

        // プレイヤー並べる
        for (int i = 0; i < TileMax; ++i)
        {
            for (int j = 0; j < TileMax; ++j)
            {
                int data = StageData[StageNo, i, j];
                if (data == 1)
                {
                    posTheif = new Vector3(j * TileLength - TotalTileLength / 2.0f,
                             0.0f,
                             i * (-1.0f) * TileLength + TotalTileLength / 2.0f);
                    Theif.SetX(i);
                    Theif.SetZ(j);
                }
                else if (data == 2)
                {
                    posPolice1 = new Vector3(j * TileLength - TotalTileLength / 2.0f,
                            0.0f,
                            i * (-1.0f) * TileLength + TotalTileLength / 2.0f);
                    Police1.SetX(i);
                    Police1.SetZ(j);
                }
                else if (data == 3)
                {
                    posPolice2 = new Vector3(j * TileLength - TotalTileLength / 2.0f,
                            0.0f,
                            i * (-1.0f) * TileLength + TotalTileLength / 2.0f);
                    Police2.SetX(i);
                    Police2.SetZ(j);
                }
            }
        }
        Debug.Log(posTheif);

        GameObjTheif = Instantiate(ObjTheif, posTheif, Quaternion.identity);
        GameObjPolice1 = Instantiate(ObjPolice1, posPolice1, Quaternion.identity);
        GameObjPolice2 = Instantiate(ObjPolice2, posPolice2, Quaternion.identity);
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

        // input
        InputPlayer();

        // 泥棒表示
        DrawTheif();

        // 警察表示
        DrawPolice1();
        DrawPolice2();
    }

    // プレイヤー入力
    void InputPlayer()
    {
        // 泥棒
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            int x = Theif.GetX();
            x -= 1;
            if (x >= 0)
            {
                Theif.SetX(x);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int x = Theif.GetX();
            x += 1;
            if (x < StageTileNumMax)
            {
                Theif.SetX(x);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int z = Theif.GetZ();
            z -= 1;
            if (z >= 0)
            {
                Theif.SetZ(z);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int z = Theif.GetZ();
            z += 1;
            if (z < StageTileNumMax)
            {
                Theif.SetZ(z);
            }

        }

    }

    // 泥棒表示
    void DrawTheif()
    {
        Vector3 posTheif = new Vector3(3, 0, 0);
        int x;
        int z;

        x = Theif.GetX();
        z = Theif.GetZ();

        posTheif = new Vector3(z * TileLength - TotalTileLength / 2.0f,
                 0.0f,
                 x * (-1.0f) * TileLength + TotalTileLength / 2.0f);

        GameObjTheif.transform.position = posTheif;
    }

    // 警察表示1
    void DrawPolice1()
    {
        Vector3 posPolice = new Vector3(3, 0, 0);
        int x;
        int z;

        x = Police1.GetX();
        z = Police1.GetZ();

        posPolice = new Vector3(z * TileLength - TotalTileLength / 2.0f,
                 0.0f,
                 x * (-1.0f) * TileLength + TotalTileLength / 2.0f);

        GameObjPolice1.transform.position = posPolice;
    }

    // 警察表示2
    void DrawPolice2()
    {
        Vector3 posPolice = new Vector3(3, 0, 0);
        int x;
        int z;

        x = Police1.GetX();
        z = Police1.GetZ();

        posPolice = new Vector3(z * TileLength - TotalTileLength / 2.0f,
                 0.0f,
                 x * (-1.0f) * TileLength + TotalTileLength / 2.0f);

        GameObjPolice1.transform.position = posPolice;
    }

}
