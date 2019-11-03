using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Stage1");
            }
        }
        else  if (SceneManager.GetActiveScene().name == "Stage1")
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("Credit");
            }
        }
    }
}
