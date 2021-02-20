using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    float lives;
    Text livesText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void AddLives(int amount)
    {
        lives += amount;
        UpdateDisplay();
    }

    public void TakeLives(int damage)
    {
        if (lives >= damage)
        {
            lives -= damage;
            UpdateDisplay();
        }
        else
        {
            lives = 0;
            UpdateDisplay();
        }

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
