using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerHp : MonoBehaviour
{
    public static int HP = 150;
    public Text HPText;
    private bool alive = true;
    public static bool worldAlive = true;

    private void Start()
    {
        HP = 150;
    }
    // Update is called once per frame
    void Update()
    {
        worldAlive = alive;
        HPText.text = HP.ToString();
        if(HP <= 0)
        {
            alive = false;
        }
        else
        {
            alive = true;
        }
    }
    public static void Bum(int value)
    {
        HP -= value;
        if(HP > 150)
        {
            HP = 150;
        }
    }

}
