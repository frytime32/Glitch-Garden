using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }
    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 adjustedWorldPosition = new Vector2((float) Mathf.RoundToInt(worldPosition.x), (float)Mathf.RoundToInt(worldPosition.y));
        return adjustedWorldPosition;
    }

    private void SpawnDefender(Vector2 spawnCoordinate)
    {
        if (defender != null)
        {
            Defender newDefender = Instantiate(defender, spawnCoordinate, Quaternion.identity) as Defender;
            newDefender.transform.parent = defenderParent.transform;
        }
    }
}
