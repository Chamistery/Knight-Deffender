using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanScript : MonoBehaviour
{
    public GameObject hp;
    public GameObject health;
    public GameObject muscles;
    public static float SlowTime = 1.5f;
    public static bool Slowing;
    private bool attacking;
    private void Update()
    {
        if (Pause_Menu.retryed)
        {
            Slowing = false;
            attacking = false;
        }
        else
        {
            if (hp.GetComponent<HP>().CurHp <= 0)
            {
                Slowing = false;
                attacking = false;
                Destroy(this.gameObject);
                hp.GetComponent<HP>().Delete();
                int a = Random.Range(0, 101);
                if (a < 21)
                {
                    GameObject healthy = GameObject.Instantiate(health, new Vector3(transform.position.x - 1, transform.position.y + 1.5f, 0f), Quaternion.identity) as GameObject;
                }
                if (21 < a && a < 41)
                {
                    GameObject muscle = GameObject.Instantiate(muscles, new Vector3(transform.position.x - 1, transform.position.y + 1.5f, 0f), Quaternion.identity) as GameObject;
                }
            }
            else
            {
                if (!Slowing && !attacking)
                {
                    StartCoroutine(Attack(SlowTime));
                }
            }
        }
    }
    private IEnumerator Attack(float time)
    {
        attacking = true;
        yield return new WaitForSeconds(1f);
        Slowing = true;
        yield return new WaitForSeconds(time);
        attacking = false;
        Slowing = false;
    }
    private void Death()
    {
        //  MoveToWayPoints.Kills++;
      //  PlayerController.enemy = null;
        Destroy(this.gameObject);
        // Destroy(hp);
        hp.GetComponent<HP>().Delete();
    }
}
