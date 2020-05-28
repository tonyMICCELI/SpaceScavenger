using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public int winCondition;
    public int winCondition2;
    public string level;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        textMetal.text = scoreObject.ToString() + " / " + winCondition.ToString();
        textWheel.text = scoreWheel.ToString() + " / " + winCondition.ToString();
        textObject.text = scoreMetal.ToString() + " / " + winCondition.ToString();
        textPanel.text = scorePanel.ToString() + " / " + winCondition.ToString();
        textGas.text = scoreGas.ToString() + " / " + winCondition2.ToString();
        textPlastic.text = scorePlastic.ToString() + " / " + winCondition2.ToString();
        textSatellite.text = scoreSatellite.ToString() + " / " + winCondition2.ToString();
    }

    private void Update()
    {
        if(scoreObject >= winCondition && scoreWheel >= winCondition && scoreMetal >= winCondition && scorePanel >= winCondition
            && scoreGas >= winCondition2 && scorePlastic >= winCondition2 && scoreSatellite >= winCondition2)
        {
            SceneManager.LoadScene(level);
        }
    }
    public void ChangeScoreMetal()
    {
        scoreObject++;
        textMetal.text = scoreObject.ToString() + " / "+  winCondition.ToString();
    }

    public void ChangeScoreWheel()
    {
        scoreWheel++;
        textWheel.text = scoreWheel.ToString() + " / " + winCondition.ToString();
    }

    public void ChangeScoreTestObject()
    {
        scoreMetal++;
        textObject.text = scoreMetal.ToString() + " / " + winCondition.ToString();
    }

    public void ChangeScorePanel()
    {
        scorePanel++;
        textPanel.text = scorePanel.ToString() + " / " + winCondition.ToString();
    }

    public void ChangeScoreGas()
    {
        scoreGas++;
        textGas.text = scoreGas.ToString() + " / " + winCondition2.ToString();
    }
    public void ChangeScorePlastic()
    {
        scorePlastic++;
        textPlastic.text = scorePlastic.ToString() + " / " + winCondition2.ToString();
    }
    public void ChangeScoreSatellite()
    {
        scoreSatellite++;
        textSatellite.text = scoreSatellite.ToString() + " / " + winCondition2.ToString();
    }

}
