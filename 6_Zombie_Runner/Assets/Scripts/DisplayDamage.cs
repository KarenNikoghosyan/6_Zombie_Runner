using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float impactTime = 1.5f;
    [SerializeField] Slider healthBar;
    [SerializeField] RawImage bloodSplash;

    private void Start()
    {
        bloodSplash.gameObject.SetActive(false);   
    }

    public void HealthBar(float damage)
    {
        healthBar.value -= damage;
    }

    IEnumerator SplashDisabled()
    {
        yield return new WaitForSeconds(impactTime);
        bloodSplash.gameObject.SetActive(false);
    }

    public void BloodSplash(bool isHit)
    {
        if (isHit)
        {
            if (bloodSplash.gameObject.activeSelf == false)
            {
                bloodSplash.gameObject.SetActive(true);
                StartCoroutine(SplashDisabled());
            }
        }
    }
}
