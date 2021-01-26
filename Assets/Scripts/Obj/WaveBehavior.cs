using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 波次的行为
/// </summary>
public class WaveBehavior
{
    List<WaveBase> waveBaseList = null;
    MonoBehaviour mono = null;

    #region 完成此次波次条件
    float timer = 0f;
    float maxTimer = 0f;
    int nextWaveActiveNum = 0;
    bool overSpwan = false;
    public int aliveEnemyNum = 0;
    #endregion



    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="wb"></param>
    /// <param name="mb"></param>
    public void Init(List<WaveBase> wb, MonoBehaviour mb)
    {
        waveBaseList = wb;
        mono = mb;  
    }

    /// <summary>
    /// 重置
    /// </summary>
    public void Reset()
    {
        waveBaseList.Clear();
        waveBaseList = null;
        mono = null;
        timer = 0f;
    }

    /// <summary>
    /// 激活波次
    /// </summary>
    public void Active()
    {
        for(int i = 0; i < waveBaseList.Count; i++)
        {
            WaveBase wave = waveBaseList[i];
            mono.StartCoroutine(IActivePoint(i, wave));
            maxTimer = Mathf.Max(maxTimer, wave.MaxTime/1000);
            nextWaveActiveNum = Mathf.Max(nextWaveActiveNum, wave.NextWaveActiveNum);
        }
    }

    /// <summary>
    /// 更新波次行为
    /// </summary>
    public bool Update()
    {
        if (overSpwan)
        {
            //timer += Time.deltaTime;
            if ((timer >= maxTimer || aliveEnemyNum <= nextWaveActiveNum))
                return true;
        }
        return false;
    }

    IEnumerator IActivePoint(int waveIndex,WaveBase wave)
    {
        //等待当前点激活时间
        yield return new WaitForSeconds(wave.DelayTime / 1000);
        for (int j = 0; j < wave.SpwanCount; j++)
        {
            //有可能一个点可以生成多个怪物，采用延迟生成
            mono.StartCoroutine(ISpwanEnemy(waveIndex, j, wave));
        }
    }

    
    IEnumerator ISpwanEnemy(int waveIndex,int spwanIndex, WaveBase wave)
    {
        yield return new WaitForSeconds(wave.SpwanInterval/1000 * spwanIndex);
        Transform point = SceneManager.Instance.enemyPoints.FindPointByID(wave.PointID);
        SceneManager.Instance.enemyManager.Spwan(wave.EnemyID,point);
        aliveEnemyNum++;
        if (waveIndex == waveBaseList.Count - 1 && spwanIndex == wave.SpwanCount - 1)
        {
            overSpwan = true;
        }
    }





}
        