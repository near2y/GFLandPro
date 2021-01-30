using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager :  MonoBehaviour
{
    /// <summary>
    /// 怪物参数表
    /// </summary>
    EnemyData enemyData;
    /// <summary>
    /// 当前正在场上的敌人集合
    /// </summary>
    public List<Enemy> enemyList;

    public int enemyAliveCount = 0;

    void Start()
    {
        enemyData = ConfigerManager.Instance.FindData<EnemyData>(CFG.TABLE_ENEMY);
        enemyList = new List<Enemy>();
    }

    /// <summary>
    /// 生成敌人
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Enemy Spwan(int id,Transform fullPoint,bool extra =false)
    {
        //生成
        EnemyBase data = enemyData.FindByID(id);
        Enemy enemy = ObjectManager.Instance.InstantiateObject(data.PrefabPath).GetComponent<Enemy>();
        enemy.transform.SetParent(transform);
        //Enemy enemy = obj.GetComponent<Enemy>();
        //enemy.Init(data);

        ////TODO位置
        //obj.transform.position = fullPoint.position;
        //obj.transform.rotation = fullPoint.rotation;
        enemy.InStage(SceneManager.Instance.player.transform,fullPoint);
        enemy.hp = data.Hp;
        //计数
        if(!extra)enemyAliveCount++;
        return enemy;
    }

    /// <summary>
    /// 找到最近的敌人
    /// </summary>
    /// <returns></returns>
    public Enemy FindCloseEnemy(float attackDis)
    {
        Enemy enemy = null;
        float standard = attackDis * attackDis;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].died || enemyList[i].targetSqrDis>standard) continue;
            if(enemy == null)
            {
                enemy = enemyList[i];
            }
            if (enemy.targetSqrDis > enemyList[i].targetSqrDis)
            {
                enemy = enemyList[i];
            }
        }
        return enemy;
    }

    public void ClearEnemy(Enemy enemy,bool extra = false)
    {
        if (enemy != null)
        {
            enemy.Release();
            enemyList.Remove(enemy);
            if(!extra)SceneManager.Instance.waveManager.CurrentWave.aliveEnemyNum--;
            if(!extra)enemyAliveCount--;
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemyList.Add(enemy);
    }

}
