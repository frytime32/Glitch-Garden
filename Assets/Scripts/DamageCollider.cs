using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            LivesDisplay livesDisplay = FindObjectOfType<LivesDisplay>();
            livesDisplay.TakeLives(attacker.GetLivesDamage());
            Destroy(attacker.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
