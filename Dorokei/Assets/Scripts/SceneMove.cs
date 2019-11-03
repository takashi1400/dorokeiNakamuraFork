using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    private bool flag_start;

    [SerializeField]
    private Image _imageMask_setumei;
    // Start is called before the first frame update
    void Start()
    {
       // flag_start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Rule");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Rule")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Stage1");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Stage1")
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("Credit");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Credit")
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("Start");
            }
        }

     }
}

