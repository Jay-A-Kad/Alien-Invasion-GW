using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimeHUD : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float timeElapsed = 0f;

    void Start()
    {
        if (timeText != null)
        {
            StartCoroutine(UpdateTime());
        }
    }

    IEnumerator UpdateTime()
    {
        while (true)
        {
            timeElapsed += Time.deltaTime;
            int seconds = Mathf.FloorToInt(timeElapsed);
            timeText.text = seconds.ToString();


            yield return null;
        }
    }
}