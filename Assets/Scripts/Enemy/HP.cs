using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public GameObject enemy;
    public int CurHp = 30;
    public void Dmg(int value, int num)
    {
        Tower.index = num;
        //  Debug.Log("Damaged");
        if (this.gameObject != null)
        {
            CurHp -= value;
        }
    }

    public void Delete()
    {
        Destroy(this.gameObject);
        MoveToWayPoints.Kills++;
    }

    void Update()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position);
        GetComponent<Text>().text = CurHp.ToString();
    }
}
