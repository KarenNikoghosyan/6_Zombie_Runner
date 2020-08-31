using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 25f;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    public void AttackHitEvent()
    {
        if (target == null) { return; }
        else
        {
            target.TakeDamage(damage);
            print("A zombie is attacking you... run you fool...");
        }
    }
}
