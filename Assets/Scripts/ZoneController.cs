using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player 1")
        {
            GameManager.instance.PlayerTwoWin();
        }
        else if (other.gameObject.name == "Player 2")
        {
            GameManager.instance.PlayerOneWin();
        }
    }
}
