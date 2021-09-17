using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{

    public GameObject prefab;
    public int numberToCreate;

    UICONTROLLER uiCont;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        uiCont = GameObject.Find("UICONTROLLER").GetComponent<UICONTROLLER>();
        //numberToCreate = uiCont.levelBTN.Length;
        Populate();
    }

    private void Populate()
    {
        GameObject newObj;
        for (int i = 0; i < numberToCreate; i++)
        {
            newObj = Instantiate(uiCont.levelBTN[i % 10], transform);
            newObj.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            uiCont.levelBTNClone[i] = transform.GetChild(i).gameObject;

        }
    }
}
