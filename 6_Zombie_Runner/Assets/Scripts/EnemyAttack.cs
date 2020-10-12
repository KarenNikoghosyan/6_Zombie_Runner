using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 25f;

    PlayerHealth target;
    DisplayDamage hpBar, bloodSplash;

    bool isHit = true;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        hpBar = FindObjectOfType<DisplayDamage>();
        bloodSplash = FindObjectOfType<DisplayDamage>();
    }
    public void AttackHitEvent()
    {
        if (target == null) { return; }
        else
        {
            target.TakeDamage(damage);
            hpBar.HealthBar(damage);
            bloodSplash.BloodSplash(isHit);
        }
    }
}
