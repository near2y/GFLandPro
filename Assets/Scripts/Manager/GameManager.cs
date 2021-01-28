using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("测试使用")]
    public string  waveID = "0101";

    [HideInInspector]
    public WaveData waveData;

    [HideInInspector]
    public EffectData effectData;

    private void Start()
    {
        effectData = ConfigerManager.Instance.FindData<EffectData>(CFG.TABLE_BULLET);
    }

    public void GameStart()
    {
        string wavePath = "Assets/RealFram/Data/Binary/WaveData_"+waveID+".bytes";
        waveData = ConfigerManager.Instance.FindData<WaveData>(wavePath);
        GameMapManager.Instance.LoadScene(waveData.AllWaveList[0].SceneName, 2);
    }

    public void GameOver()
    {

    }
}

