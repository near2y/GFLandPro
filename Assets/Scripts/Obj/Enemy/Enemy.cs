using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class  Enemy : MonoBehaviour
{
    [Header("< 怪物参数相关 >")]
    //攻击射程
    public float attackRange;
    //攻击间隔
    public float attackInterval;
    //血量
    public float hp;
    //移动速度比例
    public float walkSpeedRatio = 1;
    //攻击速度比例
    public float attackSpeedRatio = 1;
    //登场速度比例
    public float inStageSpeedRatio = 1;
    //怪物材质
    public Renderer meshRenderer = null;
    //怪物爆炸特效大小
    public float boomEffectSize = 1;

    [Header("< 调试相关 >")]
    public Transform startPos;
    public Transform agentTarget;
    public Emitter emitter = null;


    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Collider bodyCollider;
    [HideInInspector]
    public float targetSqrDis;
    [HideInInspector]
    public bool completeInStage= false;
    [HideInInspector]
    public float attackTimer = 0;

    [HideInInspector]
    public int id_Attack = Animator.StringToHash("Attack");

    [HideInInspector]
    public bool died = false;
    [HideInInspector]
    public bool lookPlayerInAttack = false;
    protected float startColorRange = 1;

    protected float startAniSpeed = 0;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        bodyCollider = GetComponent<Collider>();
        emitter = GetComponent<Emitter>();
    }

    //把敌人放入场景中
    public abstract void InStage(Transform target, Transform spwanPoint);

    //初始化
    protected void Init(Transform target, Transform start)
    {
        //由于没有放回到隐藏对象的子物体，需要考虑是否隐藏的情况
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        //初始化该对象的动作行为
        EnemyBehaviorBase[] behaviours = anim.GetBehaviours<EnemyBehaviorBase>();
        foreach (EnemyBehaviorBase behaviour in behaviours)
        {
            behaviour.enemy = this;
        }
        //攻击范围
        //agent.stoppingDistance = attackRange;
        //初始位置
        transform.position = start.position;
        transform.rotation = start.rotation;
        //攻击对象
        agentTarget = target;
        //不再处于死亡状态
        died = false;
        //恢复render
        if (meshRenderer != null)
        {
            meshRenderer.material.SetFloat("_DissvoleRange", 0);
            meshRenderer.material.SetFloat("_colorrange", startColorRange);
        }
        //开启emitter
        if(emitter != null)emitter.SetActive(true);
        startAniSpeed = anim.speed;

        //attackTimer
        attackTimer = attackInterval;
    }



    public void Release()
    {
        anim.speed = startAniSpeed;
        attackTimer = attackInterval;
        ObjectManager.Instance.ReleaseObject(gameObject,recycleParent:false);
    }

    public void Dying()
    {
        if(emitter!=null)emitter.SetActive(false);
        died = true;
        anim.Play(EnemyState.Dying);
        //手机震动
        //Handheld.Vibrate();
        //相机震动
        SceneManager.Instance.gameCamera.ShakeCamera(Random.Range(1,3), Random.Range(0.1f,0.3f));
        //变黑
        if (meshRenderer != null)
        {
            meshRenderer.material.SetFloat("_colorrange", 0.3f);
        }
        //爆炸特效
        GameObject boomEffect = SceneManager.Instance.effectManager.GetEffect(4005);
        boomEffect.transform.localScale = Vector3.one * boomEffectSize;
        boomEffect.transform.position = transform.position;

    }

    protected void Update()
    {
        if (!died)
        {
            targetSqrDis = Vector3.SqrMagnitude(transform.position - agentTarget.position);
            if (hitting)
            {
                float res = Mathf.Lerp(meshRenderer.material.GetFloat("_colorrange"), startColorRange, 50 * Time.deltaTime);
                if (res - startColorRange < 0.3f)
                {
                    hitting = false;
                    res = startColorRange;
                }
                meshRenderer.material.SetFloat("_colorrange", res);
            }
        }
    }

    protected bool hitting = false;
    protected void OnHit()
    {
        if (meshRenderer == null) return;
        meshRenderer.material.SetFloat("_colorrange", 15);
        hitting = true;
    }
}


public class EnemyState
{
    public static string InStage = "InStage";
    public static string Walk = "Walk";
    public static string Dying = "Dying";
    public static string Attack = "Attack";
}
