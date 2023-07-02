using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    public float BestResult { get; private set; }
    public static float bestie;
    public void Startup(NetworkService service)
    {
        BestResult = 1;

        Debug.Log("Result manager starting...");
        _network = service;

        status = ManagerStatus.Started;
    }
    private void Update()
    {
        bestie = BestResult;
        if(BestResult <= WaveSpawn.WaveCount)
        {
            UpdateData(WaveSpawn.WaveCount);
        }
    }
    public  void UpdateData(float result)
    {
        BestResult = result;
        Debug.Log(BestResult);
    }
}
