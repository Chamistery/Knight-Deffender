using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text1 : MonoBehaviour
{
    private float change;
    public CanvasGroup prozr;
    private bool index = false;
    private bool flag = false;
    public GameObject nag;
    public static bool starting = true;
    private bool flagofshit;
    [SerializeField] private GameObject SoundBar;
    [SerializeField] private GameObject Menu;
    // Start is called before the first frame update
    private void Awake()
    {
        nag.SetActive(true);
        Time.timeScale = 0f;
        Pause_Menu.GameIsPaused = true;
        SoundBar.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKey("space") && starting && !flagofshit)
        {
            flagofshit = true;
            Pause_Menu.MSelector++;
            SoundBar.transform.SetParent(Menu.transform);
            Pause_Menu.flag = true;
            StartCoroutine(FrameofStart());
            Time.timeScale = 1f;
            Pause_Menu.GameIsPaused = false;
            nag.SetActive(false);
        }
    //    Pause_Menu.
        if (index == true && !flag)
        {
            StartCoroutine("CoroutinesPlus");
        }
        else  if (!flag) StartCoroutine("CoroutinesMinus");
    }
    IEnumerator FrameofStart()
    {
        yield return null;
        starting = false;
    }
    IEnumerator CoroutinesPlus()
    {
        flag = true;
        for (float f = 0f; f <= 1; f += 0.002f)
        {
            prozr.alpha = f;
            yield return new WaitForEndOfFrame();
        }
        index = false;
        flag = false;
    }

    IEnumerator CoroutinesMinus()
    {
        flag = true;
        for (float f = 1f; f >= 0; f -= 0.002f)
        {
            prozr.alpha = f;
            yield return new WaitForEndOfFrame();
        }
        index = true;
        flag = false;
    }
}
