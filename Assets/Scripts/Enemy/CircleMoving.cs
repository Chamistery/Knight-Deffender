using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoving : MonoBehaviour
{
    public float angle=0;
    public float radius=0.5f;
    public float speed = 5f;
    public bool isCircle = false;
    // Start is called before the first frame update
    void Start()
    {
        isCircle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Text1.starting)
        {
            isCircle = true;
        }
        if(Text1.starting|| WaveSpawn.worldpause||Pause_Menu.GameIsPaused)
        {
            isCircle = false;
        }
        if (isCircle)
        {
            angle += speed * Time.deltaTime;

            var x = Mathf.Cos(angle) * radius*1.77f;
            var y = Mathf.Sin(angle) * radius;
            this.transform.position = new Vector2(x, y);
            this.transform.rotation = Quaternion.Euler(0, 0, (angle-1.57f+speed*Time.deltaTime)*57);
                // new Vector3(0, 0, angle);
        }
    }
}
