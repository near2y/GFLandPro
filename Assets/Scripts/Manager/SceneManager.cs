using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoSingleton<SceneManager>
{
    [Header("< 设置 >")]
    public Transform effectParent = null;

    public Player player;
    public EnemyManager enemyManager;
    public WaveManager waveManager = null;
    public EffectManager effectManager = null;
    public Transform pointsTrans;
    public GameCamera gameCamera;
    public EnemyPoints enemyPoints;

    string playerPrePath = "Assets/枪火之地/prefabs/player.prefab";


    private void Start()
    {
        Init();
    }

    //初始化
    void Init()
    {

        //points
        enemyPoints = new EnemyPoints(pointsTrans);
        //player
        //player = ObjectManager.Instance.InstantiateObject(playerPrePath).GetComponent<Player>();
        //player.transform.SetParent(transform);
        //gameCamera.SetTarget(player.transform);
        //effectManager
        Transform parent = effectParent == null ? transform : effectParent;
        effectManager = new EffectManager(GameManager.Instance.effectData, parent);

    }

    //游戏胜利
    public void OnWin()
    {
        Debug.Log("游戏胜利了");
        player.OnWin();
    }

    //开始波次
    bool startedWave = false;
    public void StartWave()
    {
        //waveManager
        waveManager = new WaveManager(GameManager.Instance.waveData, this);
        startedWave = true;
    }

    private void Update()
    {
        if (startedWave)
        {
            waveManager.Update();
        }
    }


    

    
}
