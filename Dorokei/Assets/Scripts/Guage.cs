using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guage : MonoBehaviour
{
    Image image;
    float pasttime = 0;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        pasttime += Time.deltaTime;

        image.fillAmount = pasttime % 1f;
    }
}
