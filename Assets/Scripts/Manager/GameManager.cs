using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("测试使用")]
    public string[] waveID = {"0101"};
    int gameIndex = 0;

    [HideInInspector]
    public WaveData waveData;

    [HideInInspector]
    public EffectData effectData;

    [HideInInspector]
    public MonoBehaviour mono;


    private void Start()
    {
        mono = this;
        effectData = ConfigerManager.Instance.FindData<EffectData>(CFG.TABLE_BULLET);
    }


    public void GameStart()
    {
        //TODO
        if (gameIndex >= waveID.Length) gameIndex = 0;
        //===========================
        string wavePath = "Assets/RealFram/Data/Binary/WaveData_"+waveID[gameIndex]+".bytes";
        waveData = ConfigerManager.Instance.FindData<WaveData>(wavePath);
        GameMapManager.Instance.LoadScene(waveData.AllWaveList[0].SceneName, 2);
    }

    public void GameOver()
    {
        gameIndex++;

    }
}

