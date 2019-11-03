using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using UnityEngine;
using UnityEngine.UI;

public class AddEffect : MonoBehaviour
{
    Image image = null;
    Vector3 scale;
    float pasttime = 0;
    public float coef = 1;
    float effect_start = 0.7f;
    GameObject contollerobject;
    GameControlManager gamecontrolmanager;
    Color original_color;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        scale =  this.transform.localScale;
        contollerobject = GameObject.FindGameObjectWithTag("GameGontrolManager");
        gamecontrolmanager = contollerobject.GetComponent<GameControlManager>();
        original_color=image.color;
    }

    // Update is called once per frame
    void Update()
    {
        //pasttime += Time.deltaTime;
        var float_val = gamecontrolmanager.InputGameTimer / gamecontrolmanager.InputSpan;// pasttime - System.Math.Truncate(pasttime);

        if (float_val > effect_start)
        {
            image.color = new Color(original_color.r, original_color.g, original_color.b, (float)(float_val * float_val - 0.5));
            var scale_scolor = scale.x + coef * (float_val -effect_start) ;
            transform.localScale = new Vector3(scale_scolor, scale_scolor, scale_scolor) ;
        }
        else
        {
            image.color = new Color(0, 0, 0, 0);

            transform.localScale = scale;
        }
    }
}
