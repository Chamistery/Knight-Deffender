using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(AudioManager))]
public class Managers : MonoBehaviour
{
    public static AudioManager Audio { get; private set; }
    public static ResultManager Result { get; private set; }
    public static DataManager Data { get; private set; }
    private List<IGameManager> _startSequence;
    void Awake()
    {
        Data = GetComponent<DataManager>();
        Result = GetComponent<ResultManager>();
        Audio = GetComponent<AudioManager>(); //В этом проекте в списке AudioManager, а не PlayerManager, и т.п.
        _startSequence = new List<IGameManager>();
        _startSequence.Add(Audio);
        _startSequence.Add(Result);
        _startSequence.Add(Data);
        StartCoroutine(StartupManagers());
    }
    private IEnumerator StartupManagers()
    {
        NetworkService network = new NetworkService();
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup(network);
        }
        yield return null;
        int numModules = _startSequence.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            foreach (IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
        //    11.3.Интерфейс управления звуком 265
        if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);
            yield return null;
        }
        Debug.Log("All managers started up"); 
    } 
}