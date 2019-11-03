using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public
    [Header("ゲームタイマー")]
    public float GameTimer;

    [Header("入力回数")]
    public int GameInputCounter;

    [Header("入力の時間")]
    [SerializeField]
    float InputSpan = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        GameTimer = 0.0f;
        GameInputCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // count timer
        GameTimer += Time.deltaTime;
    }
}
