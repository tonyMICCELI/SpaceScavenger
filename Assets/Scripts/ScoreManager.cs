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
    public string switchLevel1;
    public string switchLlevel2;
    public string switchLlevel3;
    public string switchWin;
    public bool level0 = true;
    public bool level1, level2, level3 = false;
    public bool isFull = false;
    public TextMeshProUGUI goBackHome;
    public string whatSkills1;
    public GameObject playerWinner;
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
        goBackHome.text = "";
    }

    private void Update()
    {
        winTheLevel();
        if (level0 == true) { 
            FullItemsLevel0();
        }
        if ((level1 || level2) == true)
        {
            FullItemsLevel12();
        }
        GoHome();
        ChoiceLevel1();
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
            if (isFull && CheckHome.instance.GetBool() )
            {
                isFull = false;
                level0 = false;
                level1 = true;
                ResetScores();
                SettingsLevel1();
                SceneManager.LoadScene(switchLevel1);                                
            }
        }

        if (level1 == true)
        {
            if (isFull && CheckHome.instance.GetBool())
            {
                isFull = false;
                level1 = false;
                level2 = true;
                ResetScores();
                SettingsLevel2();                
                SceneManager.LoadScene(switchLlevel2);
                GivingSkillsNextLevel();
            }
        }

        if (level2 == true)
        {
            GivingSkillsNextLevel();
            if (isFull && CheckHome.instance.GetBool())
            {
                isFull = false;
                level2 = false;
                level3 = true;
                ResetScores();
                SettingsLevel2();
                SceneManager.LoadScene(switchLlevel2);
                GivingSkillsNextLevel();
            }
        }

        if (level3 == true)
        {
            GivingSkillsNextLevel();
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
        winConditionLevel0 = 1;
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
        winConditionLevel0 = 100;
        winCondition = 1;
        winCondition2 = 1;
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
        winConditionLevel0 = 100;
        winCondition = 11;
        winCondition2 = 7;
        textMetal.text = scoreObject.ToString() + " / " + winCondition.ToString();
        textWheel.text = scoreWheel.ToString() + " / " + winCondition.ToString();
        textObject.text = scoreMetal.ToString() + " / " + winCondition.ToString();
        textPanel.text = scorePanel.ToString() + " / " + winCondition.ToString();
        textGas.text = scoreGas.ToString() + " / " + winCondition2.ToString();
        textPlastic.text = scorePlastic.ToString() + " / " + winCondition2.ToString();
        textSatellite.text = scoreSatellite.ToString() + " / " + winCondition2.ToString();
    }

    public void SettingsLevel3()
    {
        winConditionLevel0 = 100;
        winCondition = 110;
        winCondition2 = 700;
        textMetal.text = "";
        textWheel.text = "";
        textObject.text = "";
        textPanel.text = "";
        textGas.text = "";
        textPlastic.text = "";
        textSatellite.text = "";
    }

    public void FullItemsLevel0()
    {
        if (scoreObject >= winConditionLevel0 && scoreWheel >= winConditionLevel0 && scoreMetal >= winConditionLevel0
            && scorePanel >= winConditionLevel0
            && scoreGas >= winConditionLevel0 && scorePlastic >= winConditionLevel0 && scoreSatellite >= winConditionLevel0) 
        {
            isFull = true;
            goBackHome.text = "RETOUR VAISSEAU";
        }

        
    }

    public void FullItemsLevel12()
    {
        if (scoreObject >= winCondition && scoreWheel >= winCondition && scoreMetal >= winCondition
            && scorePanel >= winCondition
            && scoreGas >= winCondition2 && scorePlastic >= winCondition2 && scoreSatellite >= winCondition2)
        {
            isFull = true;
            goBackHome.text = "RETOUR VAISSEAU";
        }
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

    public bool GetBoolLevel1()
    {
        return level1;
    }

    public bool GetBoolLevel2()
    {
        return level2;
    }

    public bool GetBoolLevel3()
    {
        return level2;
    }

    public void ifDeathResetSettings()
    {
        level0 = true;
        level1 = false;
        level2 = false;
        level3 = false;
        ResetScores();
        SettingsLevel0();
    }

    public void GoHome() 
    {
        if (isFull)
        {
            goBackHome.text = "RETOUR VAISSEAU";
        }
        else
        {
            goBackHome.text = "";
        }
    }

    public void ChoiceLevel1()
    {
        if (PlayerController.instance.getAccelState())
        {
            whatSkills1 = "Turbo";
        }
        else if (PlayerController.instance.getDashState())
        {
            whatSkills1 = "Dash";
        }
    }

    public void GivingSkillsNextLevel()
    {
        if (whatSkills1 == "Turbo")
        {
            PlayerController.instance.makeTrueAccel();
            if (level3)
            {
                Shield.instance.makeTrueShield();
            }
        }
        else if (whatSkills1 == "Dash")
        {
            PlayerController.instance.makeTrueDash();
            if (level3)
            {
                Shield.instance.makeTrueShield();
            }
        }
    }
}

    
