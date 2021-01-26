using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


[System.Serializable]
public class EnemyData:ExcelBase
{
#if UNITY_EDITOR
    public override void Construction()
    {
        AllEnemyList = new List<EnemyBase>();
        for (int i = 0; i < 3; i++)
        {
            EnemyBase enemy = new EnemyBase();
            enemy.Id = i + 1;
            enemy.Name = "全BUFF" + i;
            enemy.AttackDis = i + 1;
            enemy.EffectId = i + 1;
            enemy.Hp = i + 1;
            enemy.PrefabPath = "near2y";
            enemy.Size = 1;
            AllEnemyList.Add(enemy);
        }
    }
#endif

    public override void Init()
    {
        AllEnemyDic.Clear();
        for (int i = 0; i < AllEnemyList.Count; i++)
        {
            AllEnemyDic.Add(AllEnemyList[i].Id, AllEnemyList[i]);
        }
    }



    /// <summary>
    /// 通过ID查找怪物数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public EnemyBase FindByID(int id)
    {
        return AllEnemyDic[id];
    }

    [XmlIgnore]
    public Dictionary<int, EnemyBase> AllEnemyDic = new Dictionary<int, EnemyBase>();

    [XmlElement("AllEnemyList")]
    public List<EnemyBase> AllEnemyList { get; set; }

}

[System.Serializable]
public class EnemyBase
{
    [XmlAttribute("Id")]
    public int Id { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("Hp")]
    public float Hp { get; set; }

    [XmlAttribute("AttackDis")]
    public float AttackDis{ get; set; }

    [XmlAttribute("EffectId")]
    public int EffectId { get; set; }

    [XmlAttribute("PrefabPath")]
    public string PrefabPath { get; set; }

    [XmlAttribute("Size")]
    public float Size { get; set; }
}

