using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public int number;
    public static int WaveSize = 5;
    public static float WaveCount = 1;
    public GameObject[] EnemyPrefabs;
    public GameObject[] Shaman;
    public float EnemyInterval;
    public Transform spawnPoint;
    private bool flag;
    public float startTime;
    int enemyCount = 0;
    public GameObject Hp;
    public GameObject canvas;
    public Transform[] WayPoints;
    private bool Spawning = false;
    private bool pausing;
    public static int enemySizer = 0;
    public static bool worldpause;
    private bool start;
    public bool test = false;
  //  public GameObject timerText;
    void Start()
    {
        //Debug.Log(this.transform.position);
        pausing = false;
        //InvokeRepeating("SpawnEnemy", startTime, EnemyInterval);   
    }

    private void Update()
    {
        EnemyInterval= Random.Range(2, 6);
        StartCoroutine(StartWaiting());
        //if (flag)
        //{
        //    WaveSize += enemySizer;
        //    flag = false;
        //}
        worldpause = pausing;
        int a = Random.Range(0, 100);
        if (enemyCount != WaveSize && start && !test)
        {
            if (!Spawning)
            {
                if (this.transform.position.x < 9.5 && this.transform.position.x > -9.5f)
                {
                    if (this.transform.position.y < 0)
                    {
                        StartCoroutine(SpawnEnemy(EnemyPrefabs[0]));
                    }
                    else
                    {
                        StartCoroutine(SpawnEnemy(EnemyPrefabs[1]));
                    }
                }
                else
                {
                    if (this.transform.position.x > 9.5f)
                    {
                        if (a < 31)
                            StartCoroutine(SpawnEnemy(Shaman[1]));
                        else
                        {
                            StartCoroutine(SpawnEnemy(EnemyPrefabs[2]));
                        }
                    }
                    else if (this.transform.position.x < -9.5f)
                    {
                        if (a < 31)
                        {
                            StartCoroutine(SpawnEnemy(Shaman[0]));
                        }
                        else
                        {
                            StartCoroutine(SpawnEnemy(EnemyPrefabs[3]));
                        }
                    }
                }
            }
        }
        else if (!worldpause && XPBar.coeff >= 1f)
        {
            StartCoroutine(Waving());
        }
    }
    private IEnumerator StartWaiting()
    {
        yield return new WaitForSeconds(1.5f);
        start = true;
    }
    private IEnumerator Waving()
    {
        pausing = true;
        yield return new WaitForSeconds(Timer.pause + 1);
        enemyCount = 0;
        MoveToWayPoints.Kills = 0;
        int a = Random.Range(0, 3);
        WaveSize += a;
        WaveCount += 0.25f;
        pausing = false;
       // flag = true;
    }

    IEnumerator SpawnEnemy(GameObject opponent)
    {
        Spawning = true;
        enemyCount++;
        GameObject enemy = GameObject.Instantiate(opponent, spawnPoint.position, Quaternion.identity) as GameObject;
        GameObject hp = GameObject.Instantiate(Hp, Vector3.zero, Quaternion.identity) as GameObject;
        hp.transform.SetParent(canvas.transform);
        hp.GetComponent<HP>().enemy = enemy;
       // MoveToWayPoints.alive = true;
        if (opponent.GetComponent<MoveToWayPoints>() != null)
        {
            enemy.GetComponent<MoveToWayPoints>().wayPoint = WayPoints;  
            enemy.GetComponent<MoveToWayPoints>().hp = hp;
        }
        else
        {
            enemy.GetComponent<ShamanScript>().hp = hp;
        }
        yield return new WaitForSeconds(EnemyInterval);
        Spawning = false;
    }
}
