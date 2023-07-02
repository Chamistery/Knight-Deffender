using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public GameObject text;
    public static int pause = 10;
    private bool flag = false;
    void Awake()
    {
        flag = false;
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveSpawn.worldpause && !flag)
        {
            StartCoroutine(RunTimer(pause));
        }
    }
    IEnumerator RunTimer(int seconds)
    {
        flag = true;
        while (seconds >= 0 && WaveSpawn.worldpause)
        {
            if (!WaveSpawn.worldpause)
            {
                text.SetActive(false);
                break;
            }
            text.SetActive(true);
            text.GetComponent<Text>().text = seconds.ToString();
           // Debug.Log(seconds);
            yield return new WaitForSeconds(1f);
            seconds -= 1;
        }
        text.SetActive(false);
        flag = false;
    }
}
