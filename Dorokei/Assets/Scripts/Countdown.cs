using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textCountdown_number;

    [SerializeField]
    private TextMeshProUGUI _textCountdown_start;

    [SerializeField]
    private Image _imageMask;

    // Start is called before the first frame update
    void Start()
    {
        _textCountdown_number.text = "";
        _textCountdown_start.text = "";
        StartCoroutine(CountdownCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CountdownCoroutine()
    {
        _imageMask.gameObject.SetActive(true);
        _textCountdown_number.gameObject.SetActive(true);
        _textCountdown_start.gameObject.SetActive(true);

        _textCountdown_number.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textCountdown_number.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textCountdown_number.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textCountdown_number.text = "";
        _textCountdown_start.text = "START!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown_start.text = "";
        _textCountdown_start.gameObject.SetActive(false);
        _textCountdown_number.gameObject.SetActive(false);
        _imageMask.gameObject.SetActive(false);
    }

}
