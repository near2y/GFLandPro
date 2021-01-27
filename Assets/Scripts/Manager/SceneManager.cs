using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoSingleton<SceneManager>
{
    [Header("< 设置 >")]
    public Transform effectParent = null;

    [HideInInspector]
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
        //waveManager
        waveManager = new WaveManager(GameManager.Instance.waveData, this);
        //points
        enemyPoints = new EnemyPoints(pointsTrans);
        player = ObjectManager.Instance.InstantiateObject(playerPrePath).GetComponent<Player>();
        player.transform.SetParent(transform);
        gameCamera.SetTarget(player.transform);
        //effectManager
        Transform parent = effectParent == null ? transform : effectParent;
        effectManager = new EffectManager(GameManager.Instance.effectData, parent);

    }

    private void Update()
    {
        waveManager.Update();
    }


    public void GameStart()
    {
        //TODO
        //玩家登场表现
        //开始按照波次出怪
    }

    public void GamePause()
    {
        //TODO
        //游戏暂停
    }

    public void GameResume()
    {
        //TODO
        //游戏回复
    }

    public void GameOver()
    {
        //TODO
        //游戏结束
    }

    

    
}
