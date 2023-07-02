using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWayPoints : MonoBehaviour
{
    public float Speed;
    public Transform[] wayPoint;
    int CurWayPointIndex = 0;
    Rigidbody2D body;
    public static int Kills = 0;
    public GameObject hp;
    public GameObject health;
    public GameObject muscles;
    public int dmg;
    private bool flag = true;
    private bool DeathHP;
    [SerializeField] private AudioClip predamage;
    [SerializeField] private AudioSource damage;
    //   private bool alive = true;
    //public GameObject towerhps;
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (DeathTimer.end == false)
        {
            hp.SetActive(false);
            DeathHP = true;
        }
        if (CurWayPointIndex < wayPoint.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint[CurWayPointIndex].position, Time.deltaTime * Speed);
            if (Vector3.Distance(transform.position, wayPoint[CurWayPointIndex].position) <= 1f && flag && !DeathHP)
            {
                flag = false;
                StartCoroutine(waiting());
               // Death();
            }
        }

        if (hp.GetComponent<HP>().CurHp <= 0 && !DeathHP)
        {
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
    }
    private IEnumerator waiting()
    {
        damage.PlayOneShot(predamage);
        Speed = 0;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        hp.GetComponent<HP>().Delete();
        TowerHp.Bum(dmg);
        CurWayPointIndex++;
        flag = true;
    } 
    private void Death()
    {
        //  Kills++;
    //    PlayerController.enemy = null;
        Destroy(this.gameObject);
        hp.GetComponent<HP>().Delete();
    }
}
