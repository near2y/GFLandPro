using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class SceneData : ExcelBase
{
#if UNITY_EDITOR
    public override void Construction()
    {
        AllSceneList = new List<SceneBase>();
        for(int i = 0; i < 3; i++)
        {
            SceneBase scene = new SceneBase();
            scene.Id = i;
            scene.SceneName = "near2y";
            scene.WaveId = i;
            AllSceneList.Add(scene);
        }
    }
#endif

    public override void Init()
    {
        AllSceneDic.Clear();
        for(int i = 0; i < AllSceneList.Count; i++)
        {
            AllSceneDic.Add(AllSceneList[i].Id, AllSceneList[i]);
        }
    }

    public SceneBase FindByID(int id)
    {
        return AllSceneDic[id];
    }

    [XmlIgnore]
    public Dictionary<int, SceneBase> AllSceneDic = new Dictionary<int, SceneBase>();

    [XmlElement("AllSceneList")]
    public List<SceneBase> AllSceneList { get; set; }

}

[System.Serializable]
public class SceneBase
{
    [XmlAttribute("Id")]
    public int Id { get; set; }

    [XmlAttribute("SceneName")]
    public string SceneName { get; set; }

    [XmlAttribute("WaveId")]
    public int WaveId { get; set; }
}
