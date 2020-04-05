using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI textObject;
    public TextMeshProUGUI textMetal;
    int scoreMetal;
    int scoreObject;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScoreMetal()
    {
        scoreObject++;
        textMetal.text = scoreObject.ToString();
    }

    public void ChangeScoreTestObject()
    {
        scoreMetal++;
        textObject.text = scoreMetal.ToString();
    }
}
