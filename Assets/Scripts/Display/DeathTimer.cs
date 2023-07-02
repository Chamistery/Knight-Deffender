using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTimer : MonoBehaviour
{
    public GameObject text;
    public static int pause = 5;
    private bool flag = false;
    public static bool end = true;
    public GameObject endMenu;
    public GameObject result;
    public GameObject bestResult;
    [SerializeField] private AudioClip bah;
    [SerializeField] private AudioSource deathing;
    void Start()
    {
        end = true;
        LoadGame();
        endMenu.SetActive(false);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        result.GetComponent<Text>().text = WaveSpawn.WaveCount.ToString();
        bestResult.GetComponent<Text>().text = ResultManager.bestie.ToString();
       // LiveFlag = flag;
        if (!TowerHp.worldAlive && !flag)
        {
            StartCoroutine(RunTimer(pause));
        }
        if(TowerHp.worldAlive)
        {
            deathing.Stop();
            text.SetActive(false);
        }
    }
    IEnumerator RunTimer(int seconds)
    {
        text.SetActive(true);
        flag = true;
        while (seconds >= 0 && !TowerHp.worldAlive)
        {
            text.GetComponent<Text>().text = seconds.ToString();
            // Debug.Log(seconds);
            deathing.PlayOneShot(bah);
            yield return new WaitForSeconds(1f);
            deathing.Stop();
            seconds -= 1;
        }
        text.SetActive(false);
        if(seconds <= 0 && !TowerHp.worldAlive)
        {
            end = false;
            Pause_Menu.GameIsPaused = true;
            flag = true;
            SaveGame();
            endMenu.SetActive(true);
            Pause_Menu.MSelector+=2;
            Pause_Menu.flag = true;
            Time.timeScale = 0f;
        }
         else
            flag = false;
    }
    public void SaveGame()
    {
        Managers.Data.SaveGameState();
    }
    public void LoadGame()
    {
        Managers.Data.LoadGameState();
    }
}
