using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] Attacker[] attackerTypes;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (spawn) SpawnAttacker();
        } 
    }

    // Update is called once per frame
    void Update()
    {
 
        
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = attackerTypes[Random.Range(0, attackerTypes.Length)];
        Spawn(newAttacker);
    }

    public void StopSpawning()
    {
        spawn = false;
    }

}
