using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public int score = 0;
    TextMesh textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    public void Increment(int nb)
    {
        score += nb; ;
        var scoreString = score.ToString();
        while (scoreString.Length < 10)
            scoreString = "SCORE: " + scoreString;
        textMesh.text = scoreString;
    }
}
