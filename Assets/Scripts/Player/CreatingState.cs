using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingState : MonoBehaviour
{
    public GameObject player;
    private bool Respawned;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player" || collision.tag == "State") && !Respawned)
        {
            Debug.Log("collisioned");
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 0.1f,0);
        }
    }

    IEnumerator justSpawn()
    {
        Respawned = true;
        yield return new WaitForSeconds(.1f);
        Respawned = false;
    }
    private void Start()
    {
        player = GameObject.Find("Knight");
        StartCoroutine(justSpawn());
    }
    void Update()
    {
        if (Pause_Menu.retryed)
        {
            Debug.Log(this.gameObject.name);
           // Destroy(this.gameObject);
        }
        if (IsHereState.isChanged && Vector2.Distance(this.transform.position, player.transform.position) >0.1f )
        {
            Debug.Log("collisioning");
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + (IsHereState.colOfMovements * 0.1f), 0);
            IsHereState.isChanged = false;
            IsHereState.colOfMovements = 0;
        }
    }
}
