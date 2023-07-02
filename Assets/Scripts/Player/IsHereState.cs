using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHereState : MonoBehaviour
{
    //Collider2D thes;
    //private void Start()
    //{
    //    thes = this.GetComponent<Collider2D>();
    //}
    public static bool isChanged = false;
    public static int colOfMovements = 0;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "State")
        {
            colOfMovements = 0;
            isChanged = true;
            colOfMovements--;
        }
    }
    //private void Update()
    //{
    //    Collider2D touch = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down).collider;
    //    if (Vector2.Distance(this.transform.position, touch.transform.position) > 0.8f && touch.CompareTag("Player"))
    //    {
    //        colOfMovements--;
    //        isChanged = true;
    //    }
    //}
}
