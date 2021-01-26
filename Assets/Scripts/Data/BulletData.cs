using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class BulletData : ExcelBase
{
#if UNITY_EDITOR
    public override void Construction()
    {
        AllBulletList = new List<BulletBase>();
        BulletBase bulletBase = new BulletBase();
        bulletBase.Id = 0;
        bulletBase.EffectId = 1;
        bulletBase.BulletDamage = 5;
        bulletBase.ShootCound = 3;
        bulletBase.ShootSpeed = 3;
        bulletBase.ShootInterval = 5;
        bulletBase.BulletSpeed = 10;
        bulletBase.PenetrateCount = 1;
        AllBulletList.Add(bulletBase);
    }
#endif

    public override void Init()
    {
        AllBulletDic.Clear();
        for(int i = 0; i < AllBulletList.Count; i++)
        {
            AllBulletDic.Add(AllBulletList[i].Id, AllBulletList[i]);
        }
    }

    public BulletBase FindBulletById(int id)
    {
        return AllBulletDic[id];
    }

    [XmlIgnore]
    public Dictionary<int, BulletBase> AllBulletDic = new Dictionary<int, BulletBase>();

    [XmlElement("AllBulletList")]
    public List<BulletBase> AllBulletList { get; set; }

}

[System.Serializable]
public class BulletBase
{
    [XmlAttribute("Id")]
    public int Id { get; set; }
    [XmlAttribute("EffectId")]
    public int EffectId { get; set; }
    [XmlAttribute("BulletDamage")]
    public float BulletDamage { get; set; }
    [XmlAttribute("ShootCound")]
    public int ShootCound { get; set; }
    [XmlAttribute("ShootSpeed")]
    public float ShootSpeed { get; set; }
    [XmlAttribute("ShootInterval")]
    public float ShootInterval { get; set; }
    [XmlAttribute("BulletSpeed")]
    public float BulletSpeed { get; set; }
    [XmlAttribute("PenetrateCount")]
    public int PenetrateCount { get; set; }
}