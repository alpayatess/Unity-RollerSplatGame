using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameOver;
    private GameObject LevelText;
    private GameObject endPanel;
    public static Color groundColor;
    public float[] levelTime;
    public float currentLevelScore;

    public Image[] stars;
    public Transform starsObj;
    public Transform[] a;

    void Start()
    {
        endPanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        endPanel.SetActive(false);
        LevelText = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        LevelText.GetComponent<Text>().text = "LEVEL " + PlayerPrefs.GetInt("chosenlvl").ToString();

        levelTime = new float[10];
        groundColor = Random.ColorHSV();

        stars = new Image[3];
        a = new Transform[3];

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i] = GameObject.Find("Canvas").transform.GetChild(1).GetChild(2).GetChild(i + 3).GetComponent<Image>();
            a[i] = GameObject.Find("Canvas").transform.GetChild(1).GetChild(2).GetChild(i + 3);

        }

        GameOver = false;
        if (PlayerPrefs.GetInt("log") == 0)
        {
            PlayerPrefs.SetInt("chosenlvl", 1);
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("log", 1);
        }


    }

    void Update()
    {

        if (!GameOver)
        {
            checkTheScore();
        }
    }

    public void checkTheScore()
    {
        currentLevelScore += Time.deltaTime;

        if (PlayerPrefs.GetInt("gamescore") == 64 - PlayerPrefs.GetInt("inactiveWallCount"))
        {
            //if (PlayerPrefs.GetInt("chosenlvl") == PlayerPrefs.GetInt("level"))
            {
                IncreaseLevel();
            }
            GameOver = true;
            LevelText.SetActive(false);
            endPanel.SetActive(true);
            levelTime[PlayerPrefs.GetInt("chosenlvl") - 1] = currentLevelScore;
            FillTheCurrentLVLImage();
        }
    }



    public void IncreaseLevel()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);

    }
    public void levelMenuUI()
    {
        SceneManager.LoadScene(0);
    }

    public void FillTheCurrentLVLImage()
    {
        if (levelTime[PlayerPrefs.GetInt("chosenlvl") - 1] < 10)
        {
            StartCoroutine(TimeDelayForScore1());

        }

        else if (levelTime[PlayerPrefs.GetInt("chosenlvl") - 1] > 10 && levelTime[PlayerPrefs.GetInt("chosenlvl") - 1] < 20)
        {
            StartCoroutine(TimeDelayForScore2());

        }
        else
        {
            StartCoroutine(TimeDelayForScore3());

        }
    }

    public IEnumerator TimeDelayForScore1()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(starsObj, a[0].transform.position, starsObj.rotation);
        stars[0].fillAmount = 0;
        yield return new WaitForSeconds(0.5f);
        Instantiate(starsObj, a[1].transform.position, starsObj.rotation);
        stars[1].fillAmount = 0;
        yield return new WaitForSeconds(0.5f);
        Instantiate(starsObj, a[2].transform.position, starsObj.rotation);
        stars[2].fillAmount = 0;


    }

    public IEnumerator TimeDelayForScore2()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(starsObj, a[0].transform.position, starsObj.rotation);
        stars[0].fillAmount = 0;
        yield return new WaitForSeconds(0.5f);
        Instantiate(starsObj, a[1].transform.position, starsObj.rotation);
        stars[1].fillAmount = 0;       


    }

    public IEnumerator TimeDelayForScore3()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(starsObj, a[0].transform.position, starsObj.rotation);
        stars[0].fillAmount = 0;
        
    }

}
