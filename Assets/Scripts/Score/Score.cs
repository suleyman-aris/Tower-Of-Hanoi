using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text score;
    public int scoreValue = 0;

    public TouchedTower touchedTower;

    private void Start()
    {
        touchedTower.changeScore += UpdateScore;
    }

    public void UpdateScore()
    {
        scoreValue++;
        score.text = "Score " +  scoreValue.ToString();
    }
}
