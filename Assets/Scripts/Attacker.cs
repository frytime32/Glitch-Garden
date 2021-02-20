using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    float currentSpeed = 1f;
    GameObject currentTarget;
    Animator animator;
    [SerializeField] int livesDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime); // delta time makes it frame rate independent
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
            return;
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {        
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    public int GetLivesDamage()
    {
        return livesDamage;
    }
}
