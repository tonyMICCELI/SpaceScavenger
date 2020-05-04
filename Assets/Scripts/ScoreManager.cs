using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI textObject;
    public TextMeshProUGUI textMetal;
    public TextMeshProUGUI textWheel;
    public TextMeshProUGUI textPanel;
    public TextMeshProUGUI textGas;
    public TextMeshProUGUI textPlastic;
    public TextMeshProUGUI textSatellite;
    int scorePanel;
    int scoreMetal;
    int scoreObject;
    int scoreWheel;
    int scoreGas;
    int scorePlastic;
    int scoreSatellite;
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

    public void ChangeScoreWheel()
    {
        scoreWheel++;
        textWheel.text = scoreWheel.ToString();
    }

    public void ChangeScoreTestObject()
    {
        scoreMetal++;
        textObject.text = scoreMetal.ToString();
    }

    public void ChangeScorePanel()
    {
        scorePanel++;
        textPanel.text = scorePanel.ToString();
    }

    public void ChangeScoreGas()
    {
        scoreGas++;
        textGas.text = scoreGas.ToString();
    }
    public void ChangeScorePlastic()
    {
        scorePlastic++;
        textPlastic.text = scorePlastic.ToString();
    }
    public void ChangeScoreSatellite()
    {
        scoreSatellite++;
        textSatellite.text = scoreSatellite.ToString();
    }

}
