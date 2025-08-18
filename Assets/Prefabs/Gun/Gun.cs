using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public enum ShotBehavior
    {
        shot,
        blankShot,
        reload
    }
    public int totalAmt;
    [SerializeField] int hornAmt = 6;    
    [SerializeField] int currentBullet;
    [SerializeField] float shotTime;
    [SerializeField] float reloadTime;
    [SerializeField] bool isReloading;
    float nextTimeToFire;
    [SerializeField] AudioSource AS;
    [SerializeField] AudioClip shotSound;
    [SerializeField] AudioClip reloadSound;
    [SerializeField] AudioClip blankShotSound;
    [SerializeField] Animator animator;
    [SerializeField] Inventory inventory;


    public void Shot(ShotBehavior shotBehavior)
    {
        switch (shotBehavior)
        {
            case ShotBehavior.shot:
                Debug.Log("shot");
                    Shot();
                    break; 

            case ShotBehavior.blankShot:
                Debug.Log("blankShot");
                break;
            case ShotBehavior.reload:
                Debug.Log("blankShot");
                break;
        }
    }

    public void Shot()
    {if (!isReloading && Time.time >= nextTimeToFire)
        {
            totalAmt = inventory.amt;
            nextTimeToFire = Time.time + 1 / shotTime;
            if (totalAmt > 0 && currentBullet < hornAmt)
            {
                currentBullet++;
                AS.clip = shotSound;
                AS.Play();
                animator.SetTrigger("Shot");
                inventory.ChangeBulletAmt();
                Vector3 shotPoint = gameObject.transform.position; 
                EventBus.OnGoingPoint?.Invoke(shotPoint);
            }

            else if (currentBullet >= hornAmt)
            {
                isReloading = true;
                currentBullet = 0;
                StartCoroutine("Reload");
            }
            else
            {
                isReloading = true;
                StartCoroutine("Reload"); ;
            }
        }

    }

    IEnumerator Reload()
    {
        AS.clip = reloadSound;
        AS.Play();
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        StopCoroutine(Reload());
    }

}
