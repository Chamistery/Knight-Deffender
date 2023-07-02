using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    public Tower twr;
    public bool enemylock = false;
    public GameObject curTarget;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !enemylock)
        {
          //  Debug.Log("Existing");
            twr.target = other.gameObject.transform;
            curTarget = other.gameObject;
            enemylock = true;
        }
    }
    private void Update()
    {
        if (!curTarget)
        {
            enemylock = false; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.gameObject == curTarget)
        {
            enemylock = false;
        }
    }
}
