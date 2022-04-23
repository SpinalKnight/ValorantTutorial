using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;

    public float bulletSpeed;
    public Transform exitPos;

    public float bulletSpread;

    public float curBullet, totalBullet, maxClip;

    public float reloadTime;

    public bool isReloading;

    public KeyCode mainFire, altFire, reloadKey;


    // Start is called before the first frame update
    void Start()
    {
        curBullet = maxClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (curBullet > 0 && !isReloading)
        {
            if (Input.GetKeyDown(mainFire))
            {
                makeBullet();
            }

            else if (Input.GetKeyDown(altFire))
            {
                if (curBullet <= 3)
                {
                    for (int i = 0; i <= curBullet; i++)
                    {
                        makeBullet();
                    }
                }
                else
                {
                    makeBullet();
                    makeBullet();
                    makeBullet();
                }
            }
        }

        if (Input.GetKeyDown(reloadKey) && totalBullet > 0 && curBullet != maxClip){
            StartCoroutine(reload());
        }
    }
    IEnumerator reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        if (totalBullet >= maxClip)
        {
            totalBullet -= (maxClip - curBullet);
            curBullet = maxClip;
        }
        else
        {
            curBullet = totalBullet;
            totalBullet = 0;
        }
        isReloading = false;
    }

    void makeBullet()
    {
        var x = Instantiate(bullet, exitPos.position, bullet.transform.rotation);

        Vector3 newVectorForce = new Vector3(transform.forward.x + Random.Range(-bulletSpread, bulletSpread), transform.forward.y + Random.Range(-bulletSpread, bulletSpread), transform.forward.z + Random.Range(-bulletSpread, bulletSpread));

        x.GetComponent<Rigidbody>().AddForce(newVectorForce * bulletSpeed);
        Destroy(x, 5f);

        curBullet--;
    }
}
