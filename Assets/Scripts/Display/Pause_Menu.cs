using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject menuUI;
    public static bool retryed;
  //  private bool retryflag;
   // public GameObject menu;
    [SerializeField] private AudioClip Pauseclip;
    [SerializeField] private AudioSource source;
    //[SerializeField] private AudioSource source1;
    [SerializeField] private AudioClip Resumeclip;
    [SerializeField] private AudioClip Retryclip;
    [SerializeField] private string intro;
    [SerializeField] private string game;
    [SerializeField] private string pause;
    [SerializeField] private string lose;
    // public Transform pause;
    public Animator anim;
    public static int MSelector = 1;
    public GameObject timer;
    public static bool flag = true;
    public static bool RePlay = false;
    void Start()
    {
        menuUI.SetActive(false);
        MSelector = 1;
        flag = true;
        RePlay = false;
    }

    public void OnPlayMusic(int selector) 
    {
        switch (selector)
        { 
            case 1: 
                Managers.Audio.PlayIntroMusic(intro);
                UnityEngine.Cursor.visible = true;
                break; 
            case 2: 
                Managers.Audio.PlayIntroMusic(game);
                UnityEngine.Cursor.visible = false;
                break;
            case 3:
                Managers.Audio.PlayIntroMusic(pause);
                UnityEngine.Cursor.visible = true;
                RePlay = true;
                break;
            default: 
                Managers.Audio.PlayIntroMusic(lose);
                UnityEngine.Cursor.visible = true;
                break;
        }
    }
    void Update()
    {
        if (flag)
        {
            Managers.Audio.StopMusic();
            OnPlayMusic(MSelector);
            Debug.Log(MSelector);
            flag = false;
        }
    //    anim.ResetTrigger("Selected");
        if (Input.GetKeyDown(KeyCode.Escape) && DeathTimer.end && !Text1.starting)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
               // anim.SetTrigger("Normal");
                //anim.SetTrigger("Highlighted");
                Pause();
            }
        }
    }
    public void Resume()
    {
        MSelector--;
        flag = true;
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        OnSoundToggle(Resumeclip);
    }
    public void Quit()
    {
        timer.SetActive(false);
        WaveSpawn.WaveSize = 5;
        WaveSpawn.WaveCount = 1;
        WaveSpawn.worldpause = false;
        //      Debug.Log("Quit");
        Application.Quit();
        Time.timeScale = 1f;
        GameIsPaused = false;
        MoveToWayPoints.Kills = 0;
    }
    public void Pause()
    {
        // pause.transform.localScale = new Vector3(1, 1, 1);
        // anim.SetTrigger("Normal");
        MSelector++;
        flag = true;
        OnSoundToggle(Pauseclip);
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void OnSoundToggle(AudioClip clip) 
    { 
       // Managers.Audio.soundMute = !Managers.Audio.soundMute;
        Managers.Audio.PlaySound(clip);
    }
    public void Retry()
    {
        OnSoundToggle(Retryclip);
        // StartCoroutine(Retrying());
        // source1.PlayOneShot(Retryclip);
        Time.timeScale = 1f;
        //Text1.starting = true;
        //timer.SetActive(false);
        //WaveSpawn.WaveSize = 5;
        //WaveSpawn.WaveCount = 1;
        //WaveSpawn.worldpause = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //timer.SetActive(false);
        //Time.timeScale = 1f;
        //GameIsPaused = false;
        //MoveToWayPoints.Kills = 0;
        StartCoroutine(retrying());
    }
    private IEnumerator retrying()
    {
        PlayerController.coeff = 1f;
        retryed = true;
        GameObject[] find = GameObject.FindGameObjectsWithTag("State");
        foreach (GameObject finded in find)
        {
            Destroy(finded);
            Debug.Log("Delete");
        }
        //  Destroy(GameObject.Find("Slowing(Clone)"));
        yield return new WaitForSeconds(0.3f);
        retryed = false;
        Text1.starting = true;
        timer.SetActive(false);
        WaveSpawn.WaveSize = 5;
        WaveSpawn.WaveCount = 1;
        WaveSpawn.worldpause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        timer.SetActive(false);
        GameIsPaused = false;
        MoveToWayPoints.Kills = 0;
    }
}
