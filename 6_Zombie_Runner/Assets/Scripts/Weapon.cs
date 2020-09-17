using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot == true)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
            canShoot = false;
        }
        if (canShoot == false)
        {
            yield return new WaitForSeconds(timeBetweenShots);
            canShoot = true;
        }
    }
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
            {
                CreateHitImpact(hit);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target == null) return;
                target.TakeDamage(damage);
            }
 
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
