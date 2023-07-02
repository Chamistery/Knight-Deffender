using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : MonoBehaviour
{
    public float Speed;
    public Transform target;
    public Tower twr;

    private void Update()
    {
        if(target)
             transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        else
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.transform == target)
        {
            target.GetComponent<MoveToWayPoints>().hp.GetComponent<HP>().Dmg(twr.dmg, 0);
            Destroy(gameObject);
        }
    }
}
