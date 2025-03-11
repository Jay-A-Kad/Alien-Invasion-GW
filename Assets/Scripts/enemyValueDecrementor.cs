using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyValueDecrementor : MonoBehaviour
{
    public static int remainingEnemies = 12;

    public TextMeshProUGUI textMeshPro;

    public GameObject panelToActivate;

    private void OnDestroy()
    {

        remainingEnemies--;
        if (textMeshPro != null)
        {
            textMeshPro.text = "" + remainingEnemies;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI not found");
        }


        if (remainingEnemies <= 0 && panelToActivate != null)
        {
            panelToActivate.SetActive(true);
        }
    }


    void Start()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = "" + remainingEnemies;
        }
    }
}