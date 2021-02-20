using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Gravestone>() != null)
        {
            animator.SetTrigger("jumpTrigger");
        }
        else if (otherObject.GetComponent<Defender>() != null)
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
