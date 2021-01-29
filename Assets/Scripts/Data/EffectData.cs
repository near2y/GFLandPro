using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


[System.Serializable]
public class EffectData: ExcelBase
{
#if UNITY_EDITOR
    public override void Construction()
    {
        AllEffectList = new List<EffectBase>();
        for (int i = 0; i < 3; i++)
        {
            EffectBase effect = new EffectBase();
            effect.Id = i + 1;
            effect.Name = "全BUFF" + i;
            effect.PrefabPath = "near2y";
            effect.Duration = i+1;
            AllEffectList.Add(effect);
        }
    }
#endif

    public override void Init()
    {
        AllEffectDic.Clear();
        for (int i = 0; i < AllEffectList.Count; i++)
        {
            AllEffectDic.Add(AllEffectList[i].Id, AllEffectList[i]);
        }
    }



    /// <summary>
    /// 通过ID查找怪物数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public EffectBase FindByID(int id)
    {
        return AllEffectDic[id];
    }

    [XmlIgnore]
    public Dictionary<int, EffectBase> AllEffectDic = new Dictionary<int, EffectBase>();

    [XmlElement("AllEffectList")]
    public List<EffectBase> AllEffectList { get; set; }

}

[System.Serializable]
public class EffectBase
{
    [XmlAttribute("Id")]
    public int Id { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("PrefabPath")]
    public string PrefabPath { get; set; }

    [XmlAttribute("Duration")]
    public float Duration { get; set; }
}

