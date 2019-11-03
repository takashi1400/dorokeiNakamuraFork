using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
        bool visible;
        int oldx;
        int oldz;

        public int GetX()
        {
            return x;
        }
        public void SetX(int data)
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
        public bool IsVisible()
        {
            return visible;
        }
        public void SetVisible(bool val)
        {
            visible = val;
        }
        public int GetOldX()
        {
            return oldx;
        }
        public void SetOldX(int data)
        {
            oldx = data;
        }
        public int GetOldZ()
        {
            return oldz;
        }
        public void SetOldZ(int data)
        {
            oldz = data;
        }
    };

    // 宝物クラス
    class Tresure
    {
        int x;
        int z;
        int type;
        bool flagAlive;

        public int GetX()
        {
            return x;
        }
        public void SetX(int data)
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
        public int GetType()
        {
            return type;
        }
        public void SetType(int val)
        {
            type = val;
        }
        public bool isAlive()
        {
            return flagAlive;
        }
        public void SetAlive(bool isAlive)
        {
            flagAlive = isAlive;
        }
    };

    // 泥棒
    PlayerBase Theif;

    // 警察
    PlayerBase Police1;
    PlayerBase Police2;

    [Header("宝物最大数")]
    [SerializeField]
    int TresureNumMax = 6;
    int[] TresureNeedsData;
    int TresureNeed;
    int TresureTotalNum;
    int TresureGotNum;

    // 宝物
    Tresure[] Tresures;

    // 宝物 prefab
    public GameObject ObjTresureA;
    public GameObject ObjTresureB;
    public GameObject ObjTresureC;

    // 宝物実体
    GameObject[] TresureObjects;


    // Start is called before the first frame update
    void Start()
    {
        StageNo = 0;

        //Instantiate(ObjField, new Vector3(0,0,0), Quaternion.identity);
        Theif = new PlayerBase();
        Police1 = new PlayerBase();
        Police2 = new PlayerBase();

        // 宝物
        TresureTotalNum = 0;
        Tresures = new Tresure[TresureNumMax];
        TresureObjects = new GameObject[TresureNumMax];
        for (int i = 0; i < TresureNumMax; ++i)
            TresureNeedsData = new int[3] { 1, 3, 3 };
        TresureNeed = TresureNeedsData[StageNo];
        TresureGotNum = 0;

        for (int i = 0; i < TresureNumMax; ++i)
        {
            Tresures[i] = new Tresure();
            Tresures[i].SetX(-1);
            Tresures[i].SetZ(-1);
            Tresures[i].SetAlive(false);
            Tresures[i].SetType(0);
        }

        GameTimer = 0.0f;
        InputGameTimer = 0.0f;
        GameInputCounter = 0;

        TileMax = ObjField.GetComponent<field>().TileMax;
        TileLength = ObjField.GetComponent<field>().TileLength;
        StageTileMax = ObjField.GetComponent<field>().StageTileMax;
        StageTileNumMax = StageTileMax[StageNo];
        StageData = ObjField.GetComponent<field>().StageData;

        TotalTileLength = TileLength * StageTileNumMax;


        Vector3 posTheif = new Vector3(3, 0, 0);
        Vector3 posPolice1 = new Vector3(2, 0, 0);
        Vector3 posPolice2 = new Vector3(1, 0, 0);

        // プレイヤーと宝物並べる
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
                    Theif.SetVisible(true);
                    Theif.SetOldX(-1);
                    Theif.SetOldZ(-1);
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
                else if (data == 7 || data == 8 || data == 9)
                {
                    Tresures[TresureTotalNum].SetX(i);
                    Tresures[TresureTotalNum].SetZ(j);
                    Tresures[TresureTotalNum].SetAlive(true);
                    Tresures[TresureTotalNum].SetType(data);

                    GameObject obj = null;
                    switch (data)
                    {
                        case 7:
                            obj = ObjTresureA;
                            break;
                        case 8:
                            obj = ObjTresureB;
                            break;
                        case 9:
                            obj = ObjTresureC;
                            break;
                        default:
                            obj = null;
                            break;
                    }

                    TresureObjects[TresureTotalNum] =
                        Instantiate(obj, new Vector3(j * TileLength - TotalTileLength / 2.0f,
                            1.0f,
                            i * (-1.0f) * TileLength + TotalTileLength / 2.0f), Quaternion.identity);

                    ++TresureTotalNum;
                }
            }
        }

        GameObjTheif = Instantiate(ObjTheif, posTheif, Quaternion.identity);
        GameObjPolice1 = Instantiate(ObjPolice1, posPolice1, Quaternion.identity);
        GameObjPolice2 = Instantiate(ObjPolice2, posPolice2, Quaternion.identity);
    }

    bool thief_can_move = true;
    bool police1_can_move = true;
    bool police2_can_move = true;

    // Update is called once per frame
    void Update()
    {
        // count timer
        float preInputTimer = InputGameTimer;
        GameTimer += Time.deltaTime;
        InputGameTimer += Time.deltaTime;
        // input counter
        if (InputGameTimer > InputSpan)
        {
            InputGameTimer -= InputSpan;
            GameInputCounter++;

            if (Theif.GetX() == Theif.GetOldX()
                && Theif.GetZ() == Theif.GetOldZ()
                )
            {
                Theif.SetVisible(true);
            }
            else
            {
                Theif.SetVisible(false);
            }

            Theif.SetOldX(Theif.GetX());
            Theif.SetOldZ(Theif.GetZ());
            //isMoveTurn = false;
        }

        if (1.5f < InputGameTimer && InputGameTimer < 2f)
        {
            // move
            if (thief_can_move)
            {
                var tmp = MoveTheif();
                if (tmp) thief_can_move = false;
            }
            if (police1_can_move)
            {
                var tmp = MovePolice1();
                if (tmp) police1_can_move = false;
            }
            if (police2_can_move)
            {
                var tmp = MovePolice2();
                if (tmp) police2_can_move = false;
            }
        }

        if (0.8f < InputGameTimer && InputGameTimer < 1.2f)
        {
            thief_can_move = true;
            police1_can_move = true;
            police2_can_move = true;
        }

        // 宝物実行
        ExecTresure();

        // 捕まえた実行
        ExecCapture();


        // 泥棒表示
        DrawTheif();

        // 警察表示
        DrawPolice1();
        DrawPolice2();
    }

    enum Charater
    {
        Thief,
        Police1,
        Police2,
    }
    int[,] pos_buffer = new int[3, 2]{
        { -1,-1, },
        { -1,-1, },
        { -1,-1, },
    };

    //position 反映
    void ReflectPosition()
    {
        if (pos_buffer[(int)Charater.Thief, 0] != -1) Theif.SetX(pos_buffer[(int)Charater.Thief, 0]);
        if (pos_buffer[(int)Charater.Thief, 1] != -1) Theif.SetZ(pos_buffer[(int)Charater.Thief, 1]);

        if (pos_buffer[(int)Charater.Police1, 0] != -1) Police1.SetX(pos_buffer[(int)Charater.Police1, 0]);
        if (pos_buffer[(int)Charater.Police1, 1] != -1) Police1.SetZ(pos_buffer[(int)Charater.Police1, 1]);

        if (pos_buffer[(int)Charater.Police2, 0] != -1) Police2.SetX(pos_buffer[(int)Charater.Police2, 0]);
        if (pos_buffer[(int)Charater.Police2, 1] != -1) Police2.SetZ(pos_buffer[(int)Charater.Police2, 1]);

        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 2; ++j)
            {
                pos_buffer[i, j] = -1;
            }

    }

    // 泥棒移動
    bool MoveTheif()
    {
        // 過去ポジション
        int oldx = Theif.GetX();
        int oldz = Theif.GetZ();

        // 泥棒
        int x = Theif.GetX();
        int z = Theif.GetZ();
        bool moved = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            x -= 1;
            if (x >= 0
                && isMovableTheif(x, z)
                )
            {
                Theif.SetX(x);
                moved = true;
                thief_can_move = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            x += 1;
            if (x < StageTileNumMax
                && isMovableTheif(x, z)
                )
            {
                Theif.SetX(x);
                moved = true;
                thief_can_move = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            z -= 1;
            if (z >= 0
                && isMovableTheif(x, z)
                )
            {
                Theif.SetZ(z);
                moved = true;
                thief_can_move = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            z += 1;
            if (z < StageTileNumMax
                && isMovableTheif(x, z)
                )
            {
                Theif.SetZ(z);
                moved = true;
                thief_can_move = false;
            }

        }

        return moved;
    }

    // 警察1移動
    bool MovePolice1()
    {
        // 泥棒
        int x = Police1.GetX();
        int z = Police1.GetZ();
        bool moved = false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            x -= 1;
            if (x >= 0
                && isMovablePolice(x, z)
                )
            {
                Police1.SetX(x);
                //[(int)Charater.Police1, 0] = x;
                moved = true;
                police1_can_move = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            x += 1;
            if (x < StageTileNumMax
                && isMovablePolice(x, z)
                )
            {
                Police1.SetX(x);
                //pos_buffer[(int)Charater.Police1, 0] = x;

                moved = true;
                police1_can_move = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            z -= 1;
            if (z >= 0
                && isMovablePolice(x, z)
                )
            {
                Police1.SetZ(z);
                //pos_buffer[(int)Charater.Police1, 1] = z;
                moved = true;
                police1_can_move = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            z += 1;
            if (z < StageTileNumMax
                && isMovablePolice(x, z)
                )
            {
                Police1.SetZ(z);
                //pos_buffer[(int)Charater.Police1, 1] = z;
                moved = true;
                police1_can_move = false;
            }

        }
        return moved;
    }

    // 警察1移動
    bool MovePolice2()
    {
        // 泥棒
        int x = Police2.GetX();
        int z = Police2.GetZ();
        bool moved = false;
        if (Input.GetKeyDown(KeyCode.U))
        {
            x -= 1;
            if (x >= 0
                && isMovablePolice(x, z)
                )
            {
                Police2.SetX(x);
                moved = true;
                police2_can_move = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            x += 1;
            if (x < StageTileNumMax
                && isMovablePolice(x, z)
                )
            {
                Police2.SetX(x);
                moved = true;
                police2_can_move = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            z -= 1;
            if (z >= 0
                && isMovablePolice(x, z)
                )
            {
                Police2.SetZ(z);
                moved = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            z += 1;
            if (z < StageTileNumMax
                && isMovablePolice(x, z)
                )
            {
                Police2.SetZ(z);
                moved = true;
                police2_can_move = false;
            }

        }
        return moved;
    }

    // 位置チェック宝物
    bool isMovableTheif(int x, int z)
    {
        bool val = true;

        // 障害物チェック
        for (int i = 0; i < TileMax; ++i)
        {
            bool isBreak = false;
            for (int j = 0; j < TileMax; ++j)
            {
                int data = StageData[StageNo, i, j];
                if (data == 5
                    && x == i
                    && z == j
                    )
                {
                    val = false;
                    isBreak = true;
                    break;
                }
            }
            if (isBreak)
            {
                break;
            }
        }

        return val;
    }

    // 位置チェック警察
    bool isMovablePolice(int x, int z)
    {
        bool val = true;

        // 宝物チェック
        for (int i = 0; i < TresureTotalNum; ++i)
        {
            if (Tresures[i].isAlive()
                && x == Tresures[i].GetX()
                && z == Tresures[i].GetZ()
                )
            {
                val = false;
                break;
            }
        }

        // 障害物チェック
        for (int i = 0; i < TileMax; ++i)
        {
            bool isBreak = false;
            for (int j = 0; j < TileMax; ++j)
            {
                int data = StageData[StageNo, i, j];
                if (data == 5
                    && x == i
                    && z == j
                    )
                {
                    val = false;
                    isBreak = true;
                    break;
                }
            }
            if (isBreak)
            {
                break;
            }
        }

        return val;
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

        if (Theif.IsVisible())
        {
            GameObjTheif.transform.position = posTheif;
        }
        else
        {
            GameObjTheif.transform.position = new Vector3(-100, 0, -100);
        }
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

        x = Police2.GetX();
        z = Police2.GetZ();

        posPolice = new Vector3(z * TileLength - TotalTileLength / 2.0f,
                 0.0f,
                 x * (-1.0f) * TileLength + TotalTileLength / 2.0f);

        GameObjPolice2.transform.position = posPolice;
    }

    // 宝物実行
    void ExecTresure()
    {
        int x;
        int z;

        // 泥棒位置
        x = Theif.GetX();
        z = Theif.GetZ();

        // 宝物チェック
        for (int i = 0; i < TresureTotalNum; ++i)
        {
            if (Tresures[i].isAlive()
                && x == Tresures[i].GetX()
                && z == Tresures[i].GetZ()
                )
            {
                // 宝物ゲット!
                Tresures[i].SetAlive(false);
                Tresures[i].SetX(-100);
                Tresures[i].SetZ(-100);

                TresureObjects[i].transform.position = new Vector3(-100, 0, -100);
                ++TresureGotNum;

                // 泥棒勝った？
                if (++TresureGotNum >= TresureNeed)
                {
                    SceneManager.LoadScene("ThiefWin");
                }
                break;
            }
        }

    }

    // 捕まえたか実行
    void ExecCapture()
    {
        bool val = false;
        if(Theif.GetX() == Police1.GetX()
            && Theif.GetZ() == Police1.GetZ())
        {
            val = true;
        }else if (Theif.GetX() == Police2.GetX()
            && Theif.GetZ() == Police2.GetZ())
        {
            val = true;
        }

        if(val == true)
        {
            SceneManager.LoadScene("PoliceWin");
        }
    }
}