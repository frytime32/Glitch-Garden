using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time the level will last in seconds")]
    [SerializeField] float levelTimeInSeconds = 10f;
    bool timerFinished = false;
   
    // Update is called once per frame
    void Update()
    {
        if (!timerFinished)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimeInSeconds;
            if (isTimerFinished())
            {
                timerFinished = true;
                FindObjectOfType<LevelController>().LevelFinished();
            }
        }
    }

    

    public bool isTimerFinished()
    {        
        return (Time.timeSinceLevelLoad >= levelTimeInSeconds); ;
    }
}
