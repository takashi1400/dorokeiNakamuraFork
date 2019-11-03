using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guage : MonoBehaviour
{
    Image image;
//    float pasttime = 0;

    GameObject contollerobject;
    GameControlManager gamecontrolmanager;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        //
        contollerobject = GameObject.FindGameObjectWithTag("GameGontrolManager");
        gamecontrolmanager = contollerobject.GetComponent<GameControlManager>();
    }


    // Update is called once per frame
    void Update()
    {
        //pasttime += Time.deltaTime;

        image.fillAmount = gamecontrolmanager.InputGameTimer / gamecontrolmanager.InputSpan;
    }
}
