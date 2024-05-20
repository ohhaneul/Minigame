using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI text;
    int score = 0;

    private void Start()
    {
        SetText();
    }

    public void Score_200()
    {
        score += 200;
        SetText();
    }
        public void Score_300()
    {
        score += 300;
        SetText();
    }

    public void Score_1000()
    {
        score += 1000;
        SetText();
    }

    public void SetText()
    {
        text.text = "Score : " + score.ToString();
    }

}
