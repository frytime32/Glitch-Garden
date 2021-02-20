using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    Attacker[] attackers;
    bool isLevelFinished = false;
    [Tooltip("Amount of time in seconds between the end of a level and when the scene transitions")]
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] bool isLastLevel = false;
    bool hasShownLevelFinishScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        if (winLabel)
        {
            winLabel.SetActive(false);
        }
        if (loseLabel)
        {
            loseLabel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackers = FindObjectsOfType<Attacker>();
        if (attackers.Length == 0)
        {
            if (isLevelFinished && !hasShownLevelFinishScreen)
            {
                hasShownLevelFinishScreen = true;
                StartCoroutine(HandleWinCondition());
            }
        }
    }

    private static void StopAllAttackerSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    IEnumerator HandleWinCondition()
    {
        if (!hasShownLevelFinishScreen)
        {
            winLabel.SetActive(true);
        }
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        if (isLastLevel)
        {
            GetComponent<LevelLoader>().LoadVictoryScreen();
        }
        else 
        {
            GetComponent<LevelLoader>().LoadNextScene();
        }
    }

    public void HandleLoseCondition()
    {
        if (!hasShownLevelFinishScreen)
        {
            loseLabel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void LevelFinished()
    {
        StopAllAttackerSpawners();
        isLevelFinished = true;
    }
}
