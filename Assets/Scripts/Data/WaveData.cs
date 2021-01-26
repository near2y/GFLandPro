using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class WaveData : ExcelBase
{
#if UNITY_EDITOR
    public override void Construction()
    {
        AllWaveList = new List<WaveBase>();
        for (int i = 0; i < 3; i++)
        {
            WaveBase wave = new WaveBase();
            wave.ID = i + 1;
            wave.WaveID = i;
            wave.DelayTime = i;
            wave.PointID = i;
            wave.EnemyID = i;
            wave.EnemyName= "方便看";
            wave.SpwanCount = i;
            wave.SpwanInterval = i;
            wave.NextWaveActiveNum = i;
            wave.MaxTime = i;
            wave.SceneName = "scene07";
            AllWaveList.Add(wave);
        }
    }
#endif

    public override void Init()
    {
        AllWaveDic.Clear();
        for (int i = 0; i < AllWaveList.Count; i++)
        {
            AllWaveDic.Add(AllWaveList[i].ID, AllWaveList[i]);
        }
    }

    /// <summary>
    /// 通过ID查找怪物数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public WaveBase FindByID(int id)
    {
        return AllWaveDic[id];
    }


    [XmlIgnore]
    public Dictionary<int, WaveBase> AllWaveDic = new Dictionary<int, WaveBase>();

    [XmlElement("AllWaveList")]
    public List<WaveBase> AllWaveList { get; set; }

}


[System.Serializable]
public class WaveBase
{
    /// <summary>
    /// 唯一ID
    /// </summary>
    [XmlAttribute("ID")]
    public int ID { get; set; }

    /// <summary>
    /// 归属于波次的ID
    /// </summary>
    [XmlAttribute("WaveID")]
    public int WaveID { get; set; }

    /// <summary>
    /// 当前波次开始，延迟多少激活该点
    /// </summary>
    [XmlAttribute("DelayTime")]
    public float DelayTime { get; set; }

    /// <summary>
    /// 生成点ID
    /// </summary>
    [XmlAttribute("PointID")]
    public int PointID { get; set; }

    /// <summary>
    /// 生成怪物的ID
    /// </summary>
    [XmlAttribute("EnemyID")]
    public int EnemyID { get; set; }

    /// <summary>
    /// 生成怪物的名字
    /// </summary>
    [XmlElement("EnemyName")]
    public string EnemyName { get; set; }

    /// <summary>
    /// 同一个点同一个波次中总共会生成的怪物数量
    /// </summary>
    [XmlElement("SpwanCount")]
    public int SpwanCount { get; set; }
    
    /// <summary>
    /// 同一个点同一波次中生成怪物间隔
    /// </summary>
    [XmlElement("SpwanInterval")]
    public float SpwanInterval { get; set; }

    /// <summary>
    /// 剩余怪物数量小于该值激活下一波
    /// </summary>
    [XmlElement("NextWaveActiveNum")]
    public int NextWaveActiveNum { get; set; }

    /// <summary>
    /// 持续时间大于该值激活下一波
    /// </summary>
    [XmlElement("MaxTime")]
    public float MaxTime { get; set; }

    /// <summary>
    /// 场景名称
    /// </summary>
    [XmlElement("SceneName")]
    public string SceneName { get; set; }
}
