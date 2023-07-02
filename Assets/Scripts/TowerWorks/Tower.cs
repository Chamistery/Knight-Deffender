using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform shootElement;
    public int dmg = 10;
    public GameObject bullet;
    public Transform target;
    public Transform LookAtObj;
    public float shootDelay;
    public bool isShoot;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip clip;
    public static int index;

    void Update()
    {
        if (index == 1)
        {
            soundSource.PlayOneShot(clip);
            index = 0;
        }
        if (target!=null)
        {
           // Debug.Log("Exist");
            if (!isShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    IEnumerator Shoot()
    {
        isShoot = true;
        yield return new WaitForSeconds(shootDelay);
        GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
        b.GetComponent<BulletTower>().target = target;
        b.GetComponent<BulletTower>().twr = this;
        isShoot = false;
    }
}
