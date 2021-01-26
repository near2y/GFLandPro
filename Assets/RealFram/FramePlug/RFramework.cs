using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RFramework : MonoSingleton<RFramework>
{
    public RectTransform m_UIRoot = null;
    public RectTransform m_WindowRoot = null;
    public Camera m_UICamera = null;
    public EventSystem m_UIEventSystem = null;


    protected override void Awake()
    {
        base.Awake();
        GameObject.DontDestroyOnLoad(gameObject);
        AssetBundleManager.Instance.LoadAssetBundleConfig();
        ResourceManager.Instance.Init(this);
        ObjectManager.Instance.Init(transform.Find("RecyclePoolTrs"), transform.Find("SceneTrs"));
        GameMapManager.Instance.Init(this);


    }

    // Use this for initialization
    void Start ()
    {
        #region 初始化相关游戏资源
        UIManager.Instance.Init(m_UIRoot, m_WindowRoot, m_UICamera, m_UIEventSystem);
        RegisterUI();
        #endregion

        GameMapManager.Instance.LoadScene(ConStr.MENUSCENE);
        //UIManager.Instance.PopUpWindow(ConStr.MENUPANEL);
    }


    //加载配置表
    void LoadConfiger()
    {
        //加载配置表示例
        //ConfigerManager.Instance.LoadData<MonsterData>(CFG.TABLE_MONSTER);
        //ConfigerManager.Instance.LoadData<BuffData>(CFG.TABLE_BUFF);
    }
	
	// Update is called once per frame
	void Update ()
    {
        UIManager.Instance.OnUpdate();
	}

    private void OnApplicationQuit()
    {
#if UNITY_EDITOR
        ResourceManager.Instance.ClearCache();
        Resources.UnloadUnusedAssets();
        Debug.Log("清空编辑器缓存");
#endif
    }

    /// <summary>
    /// 注册UI
    /// </summary>
    private void RegisterUI()
    {
        UIManager.Instance.Register<MenuUI>(ConStr.MENUPANEL);
        UIManager.Instance.Register<LoadUI>(ConStr.LOADINGPANEL);
        UIManager.Instance.Register<GameUI>(ConStr.GAMEPANEL);
    }

}
