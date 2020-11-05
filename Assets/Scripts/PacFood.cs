using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacFood : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "pacman")
        {
            GameManager.score += 10;
            GameObject[] pacdots = GameObject.FindGameObjectsWithTag("pacdot");
            Destroy(this.gameObject);

            if (pacdots.Length == 1)
            {
                GameObject.FindObjectOfType<GameGUINavigation>().LoadLevel();
            }
        }
    }
}
