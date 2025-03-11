using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DecreaseOxygenLevels : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private float timer = 0f;
    private int number = 100;
    void Start()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = number.ToString();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            number -= 3;
            textMeshPro.text = number.ToString();
            timer = 0f;
        }
    }
}