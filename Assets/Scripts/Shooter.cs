using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        createProjectileParent();
    }

    private void createProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane())
        {
            // references the parameter set in the animator, which is used as the condition for changing animation from idle to attacking
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount > 0)
        {
            return true;
        }
        return false;
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            // Positions may not be the same, so do nearly the same bc of float math
            bool IsCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
                break;
            }
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

}
