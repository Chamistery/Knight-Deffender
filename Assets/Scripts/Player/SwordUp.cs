using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUp : MonoBehaviour
{
    public static bool BIG = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BIG = true;
            Destroy(this.gameObject);
        }
    }
}
