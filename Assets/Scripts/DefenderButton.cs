using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    private Color grayColor;
    private void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        grayColor = sprite.color;

        LabelButtons();
    }

    private void LabelButtons()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            SpriteRenderer sprite = button.GetComponent<SpriteRenderer>();
            sprite.color = grayColor;
        }

        SpriteRenderer currentSprite = GetComponent<SpriteRenderer>();
        currentSprite.color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
