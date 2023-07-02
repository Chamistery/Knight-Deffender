using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int Healing = 20;
    public static bool heal = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            heal = true;
            TowerHp.Bum(-Healing);
            Destroy(this.gameObject);
            Debug.Log("Healed +" + Healing);
        }
    }
}
