using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfHit : MonoBehaviour
{
    public static bool miss;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        miss = false;
    //        if (collision.GetComponent<MoveToWayPoints>() != null)
    //            collision.GetComponent<MoveToWayPoints>().hp.GetComponent<HP>().Dmg(10, 1);
    //        if (collision.GetComponent<ShamanScript>() != null)
    //            collision.GetComponent<ShamanScript>().hp.GetComponent<HP>().Dmg(10, 1);
    //    }
    //    else
    //    {
    //        miss = true;
    //        //if(collision.GetComponent<MoveToWayPoints>() != null)
    //        //    collision.GetComponent<MoveToWayPoints>().hp.GetComponent<HP>().Dmg(10, 1);
    //        //if(collision.GetComponent<ShamanScript>() != null)
    //        //    collision.GetComponent<ShamanScript>().hp.GetComponent<HP>().Dmg(10, 1);
    //    } 
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            miss = false;
            if (collision.GetComponent<MoveToWayPoints>() != null)
                collision.GetComponent<MoveToWayPoints>().hp.GetComponent<HP>().Dmg(10, 1);
            if (collision.GetComponent<ShamanScript>() != null)
                collision.GetComponent<ShamanScript>().hp.GetComponent<HP>().Dmg(10, 1);
        }
        else
        {
             miss = true;
                //if(collision.GetComponent<MoveToWayPoints>() != null)
                //    collision.GetComponent<MoveToWayPoints>().hp.GetComponent<HP>().Dmg(10, 1);
                //if(collision.GetComponent<ShamanScript>() != null)
                //    collision.GetComponent<ShamanScript>().hp.GetComponent<HP>().Dmg(10, 1);
        } 
    }
}
