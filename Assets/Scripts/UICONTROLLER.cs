using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICONTROLLER : MonoBehaviour
{
    public GameObject[] levelBTN;
    public GameObject[] levelBTNClone;

    PopulateGrid PG;

    RaycastHit rayhit;
    private void Awake()
    {
        PG = GameObject.Find("Scroll View").transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<PopulateGrid>();
        levelBTNClone = new GameObject[PG.numberToCreate];

    }

    void Start()
    {
        PlayerPrefs.SetInt("gamescore", 0);
        levelBTNClone[0].GetComponent<Button>().interactable = true;

        for (int i = 0; i < PlayerPrefs.GetInt("level"); i++)
        {
            levelBTNClone[i].GetComponent<Button>().interactable = true;

        }

        for (int j = 0; j < levelBTN.Length; j++)
        {
            levelBTN[j].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        hitButton();
    }
    public void OpenLevel()
    {


        PlayerPrefs.SetInt("inactiveWallCount", 0);
        PlayerPrefs.SetInt("chosenlvl", int.Parse(GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponentInChildren<Text>().text));
        SceneManager.LoadScene(PlayerPrefs.GetInt("chosenlvl"));

    }

    public void hitButton()
    {
        Ray cameraRay = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraRay, out rayhit))
        {
            Debug.Log("burda");


        }
    }
}
