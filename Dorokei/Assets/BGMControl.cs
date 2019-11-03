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

    // Start is called before the first frame update
    void Start()
    {
        contollerobject = GameObject.FindGameObjectWithTag("GameGontrolManager");

        criSource = this.GetComponent<CriAtomSource>();
        gamecontrolmanager = contollerobject.GetComponent<GameControlManager>();
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
        criSource.cueName = (period % 2 == 0) ? "chase1" : "chase2";
        this.criSource.Play();
    }
}
