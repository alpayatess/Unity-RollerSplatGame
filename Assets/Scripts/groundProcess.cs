using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundProcess : MonoBehaviour
{
    Renderer myRend;
    Color defaultColor;

    public Transform waterObj;


    void Start()
    {
        myRend = transform.parent.GetComponent<Renderer>();
        defaultColor = myRend.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            PlayerPrefs.SetInt("inactiveWallCount", PlayerPrefs.GetInt("inactiveWallCount") + 1);

        }

        if (other.tag == "Player" && myRend.material.color == defaultColor)
        {
            myRend.material.color = GameManager.groundColor;
            PlayerPrefs.SetInt("gamescore", PlayerPrefs.GetInt("gamescore") + 1);
            Instantiate(waterObj, other.transform.position, waterObj.rotation);
            Destroy(transform.gameObject.GetComponent<groundProcess>());
        }
    }
}
