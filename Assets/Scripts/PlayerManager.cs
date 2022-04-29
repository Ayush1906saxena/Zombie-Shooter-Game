using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public Text healthText;

    public GameManager gameManager;

    public void Hit(float damage)
    {
        health -= damage;

        healthText.text = health.ToString() + "HEALTH";

        if(health <= 0)
        {
            gameManager.EndGame();

        }
    }
    
}
