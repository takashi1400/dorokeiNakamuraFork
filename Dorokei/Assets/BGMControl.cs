using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControl : MonoBehaviour
{
    GameObject contollerobject;
    GameControlManager gamecontrolmanager;
    CriAtomSource criSource;
    int period = -1;

    public bool IsPinch;

    // Start is called before the first frame update
    void Start()
    {
        contollerobject = GameObject.FindGameObjectWithTag("GameGontrolManager");
        gamecontrolmanager = contollerobject.GetComponent<GameControlManager>();

        criSource = this.GetComponent<CriAtomSource>();
        //SoundPlay();
    }

    // Update is called once per frame
    void Update()
    {
        //切り替え開始で音鳴動
        if(period != gamecontrolmanager.GameInputCounter)
        {
            SoundPlay();
        }

        period = gamecontrolmanager.GameInputCounter;
    }

    private void SoundPlay()
    {
        if (IsPinch)
        {

            //サウンドパターン入れ替え
            criSource.cueName = (period % 2 == 0) ? "chase3" : "chase4";
        }
        else
        {
            //サウンドパターン入れ替え
            criSource.cueName = (period % 2 == 0) ? "chase1" : "chase2";
        }
        this.criSource.Play();
    }
}
