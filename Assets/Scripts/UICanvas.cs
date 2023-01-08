using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    public bool p1Ready, p2Ready;
    public Text p1Text, p2Text;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            p1Ready = true;
            p1Text.text = "P1 Ready!";
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            p2Ready = true;
            p2Text.text = "P2 Ready!";
        }

        if(p1Ready && p2Ready)
        {
            Debug.Log("Loading Level...");
            SceneManager.LoadScene(1);
        }
    }
}
