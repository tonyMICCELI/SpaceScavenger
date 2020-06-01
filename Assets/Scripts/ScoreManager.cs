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
    public int winConditionLevel0;
    public int winCondition;
    public int winCondition2;
    public string level;
    public bool level0 = true;
    public bool level1, level2, level3 = false;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        if (level0 == true)
        {
            SettingsLevel0();
        }

        
    }

    private void Update()
    {
        winTheLevel();
    }
    public void ChangeScoreMetal()
    {
        if (level0)
        {
            scoreObject++;
            textMetal.text = scoreObject.ToString() + " / " + winConditionLevel0.ToString();
        }
        else
        {
            scoreObject++;
            textMetal.text = scoreObject.ToString() + " / " + winCondition.ToString();
        }
        
    }
    public void ChangeScoreWheel()
    {
        if (level0)
        {
            scoreWheel++;
            textWheel.text = scoreWheel.ToString() + " / " + winConditionLevel0.ToString();
        }
        else
        {
            scoreWheel++;
            textWheel.text = scoreWheel.ToString() + " / " + winCondition.ToString();
        }
    }
    public void ChangeScoreTestObject()
    {
        if (level0)
        {
            scoreMetal++;
            textObject.text = scoreMetal.ToString() + " / " + winConditionLevel0.ToString();
        }
        else
        {
            scoreMetal++;
            textObject.text = scoreMetal.ToString() + " / " + winCondition.ToString();
        }
    }
    public void ChangeScorePanel()
    {
        if (level0)
        { 
        scorePanel++;
        textPanel.text = scorePanel.ToString() + " / " + winConditionLevel0.ToString();
        }
        else
        {
            scorePanel++;
            textPanel.text = scorePanel.ToString() + " / " + winCondition.ToString();
        }
    }
    public void ChangeScoreGas()
    {
        if (level0)
        {
            scoreGas++;
            textGas.text = scoreGas.ToString() + " / " + winConditionLevel0.ToString();
        }
        else
        {
            scoreGas++;
            textGas.text = scoreGas.ToString() + " / " + winCondition2.ToString();
        }
        
    }
    public void ChangeScorePlastic()
    {
        if (level0) { 
        scorePlastic++;
        textPlastic.text = scorePlastic.ToString() + " / " + winConditionLevel0.ToString();
        }
        else
        {
            scorePlastic++;
            textPlastic.text = scorePlastic.ToString() + " / " + winCondition2.ToString();
        }
    }
    public void ChangeScoreSatellite()
    {
        if (level0)
        {
            scoreSatellite++;
            textSatellite.text = scoreSatellite.ToString() + " / " + winConditionLevel0.ToString();
        }
        else
        {
            scoreSatellite++;
            textSatellite.text = scoreSatellite.ToString() + " / " + winCondition2.ToString();
        }
    }

    public void winTheLevel()
    {
        if (level0 == true)
        {
            if (scoreObject >= winConditionLevel0 && scoreWheel >= winConditionLevel0 && scoreMetal >= winConditionLevel0 
            && scorePanel >= winConditionLevel0
            && scoreGas >= winConditionLevel0 && scorePlastic >= winConditionLevel0 && scoreSatellite >= winConditionLevel0 && CheckHome.instance.GetBool() )
            {
                level0 = false;
                level1 = true;
                ResetScores();
                SettingsLevel1();
                SceneManager.LoadScene(level);                                
            }
        }
    }
    void Awake()
    {
        if (instance == null) //there is no ScoreManager in the scene
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    public void SettingsLevel0()
    {
        winCondition = 10;
        winCondition2 = 5;
        textMetal.text = scoreObject.ToString() + " / " + winConditionLevel0.ToString();
        textWheel.text = scoreWheel.ToString() + " / " + winConditionLevel0.ToString();
        textObject.text = scoreMetal.ToString() + " / " + winConditionLevel0.ToString();
        textPanel.text = scorePanel.ToString() + " / " + winConditionLevel0.ToString();
        textGas.text = scoreGas.ToString() + " / " + winConditionLevel0.ToString();
        textPlastic.text = scorePlastic.ToString() + " / " + winConditionLevel0.ToString();
        textSatellite.text = scoreSatellite.ToString() + " / " + winConditionLevel0.ToString();
    }

    public void SettingsLevel1()
    {
        winConditionLevel0 = 500;
        winCondition = 10;
        winCondition2 = 5;
        textMetal.text = scoreObject.ToString() + " / " + winCondition.ToString();
        textWheel.text = scoreWheel.ToString() + " / " + winCondition.ToString();
        textObject.text = scoreMetal.ToString() + " / " + winCondition.ToString();
        textPanel.text = scorePanel.ToString() + " / " + winCondition.ToString();
        textGas.text = scoreGas.ToString() + " / " + winCondition2.ToString();
        textPlastic.text = scorePlastic.ToString() + " / " + winCondition2.ToString();
        textSatellite.text = scoreSatellite.ToString() + " / " + winCondition2.ToString();
    }

    public void SettingsLevel2()
    {
        winConditionLevel0 = 500;
        winCondition = 13;
        winCondition2 = 7;
        textMetal.text = scoreObject.ToString() + " / " + winCondition.ToString();
        textWheel.text = scoreWheel.ToString() + " / " + winCondition.ToString();
        textObject.text = scoreMetal.ToString() + " / " + winCondition.ToString();
        textPanel.text = scorePanel.ToString() + " / " + winCondition.ToString();
        textGas.text = scoreGas.ToString() + " / " + winCondition2.ToString();
        textPlastic.text = scorePlastic.ToString() + " / " + winCondition2.ToString();
        textSatellite.text = scoreSatellite.ToString() + " / " + winCondition2.ToString();
    }

    public void ResetScores()
    {
        scorePanel = 0;
        scoreMetal = 0;
        scoreObject = 0;
        scoreWheel = 0;
        scoreGas = 0;
        scorePlastic = 0;
        scoreSatellite = 0;
    }


}
