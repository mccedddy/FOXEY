using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int scoreInt = 0;
    private void Start()
    {
        scoreInt = 0;
    }
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + scoreInt.ToString();
    }
    public static void AddScore(int scoreToAdd)
    {
        scoreInt += scoreToAdd;
    }
}
