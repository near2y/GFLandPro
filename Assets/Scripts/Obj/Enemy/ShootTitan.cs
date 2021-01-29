using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTitan : Enemy
{

    [HideInInspector]
    public int id_AttackType = Animator.StringToHash("AttackType");
    [HideInInspector]
    public int id_AmmoCount = Animator.StringToHash("AmmoCount");

    [Header("< 射击泰坦相关属性接口 >")]
    public Transform leftHand;
    public Transform rightHand;
    public GameObject ammoPre;
    //泰坦攻击弹药
    int ammoCount = 0;
    float ammoInterval = 3000;
    float ammoTimer = 0;

    private void Start()
    {
        InStage(agentTarget, startPos);
        //保证登场后不久会进行上弹
        ammoTimer = ammoInterval - 500;
    }

    public override void InStage(Transform target, Transform spwanPoint)
    {
        Init(target, spwanPoint);

        //登场
        anim.Play(EnemyState.InStage);

        //攻击类型
        anim.SetFloat(id_AttackType, 1);

    }

    //上完弹药
    void LoadedAmmo()
    {
        Mine ammo1 = Instantiate(ammoPre).GetComponent<Mine>();
        Mine ammo2 = Instantiate(ammoPre).GetComponent<Mine>();
        ammo1.InStage(agentTarget, leftHand);
        ammo2.InStage(agentTarget, rightHand);

    }

    //发射炮弹
    void ShootAmmo()
    {


    }



    new void Update()
    {
        base.Update();
        if (completeInStage)
        {
            ammoTimer += Time.deltaTime*1000;
            if(ammoCount<=0 && ammoTimer>=ammoInterval)
            {
                ammoCount++;
                //播放上弹动作
                anim.Play("Loaded", 1);
            }
        }
    }
}


