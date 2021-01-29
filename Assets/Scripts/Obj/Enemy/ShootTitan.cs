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
    public int ammoID;
    //泰坦攻击弹药
    bool couldShoot = false;
    float ammoInterval = 3000;
    float ammoTimer = 0;
    Mine leftAmmo = null;
    Mine rightAmmo = null;

    private void Start()
    {
        //InStage(agentTarget, startPos);
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
    void LoadedAmmo(int isLeft)
    {
        if (isLeft == 1)
        {
            leftAmmo = SceneManager.Instance.enemyManager.Spwan(ammoID, transform) as Mine;
            leftAmmo.InStage(agentTarget,leftHand);
        }
        else
        {
            rightAmmo = SceneManager.Instance.enemyManager.Spwan(ammoID, transform) as Mine;
            rightAmmo.InStage(agentTarget,rightHand);
        }
    }

    //发射炮弹
    void ShootAmmo(int isLeft)
    {
        if (isLeft == 1)
        {
            leftAmmo.BeShoot();
            leftAmmo = null;
        }
        else
        {
            rightAmmo.BeShoot();
            rightAmmo = null;

        }
        couldShoot = !(leftAmmo== null && rightAmmo==null);
        ammoTimer = 0;
    }



    new void Update()
    {
        base.Update();
        if (completeInStage)
        {
            ammoTimer += Time.deltaTime*1000;
            if(!couldShoot && ammoTimer>=ammoInterval)
            {
                couldShoot = true;
                //播放上弹动作
                anim.Play("Loaded", 1);
            }
        }
        if (!couldShoot)
        {
            attackTimer = 0;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        hp -= SceneManager.Instance.player.ATK;
        OnHit();
        if (hp <= 0 && !died)
        {
            if (leftAmmo != null) {}SceneManager.Instance.enemyManager.ClearEnemy(leftAmmo,true);
            if (rightAmmo != null) SceneManager.Instance.enemyManager.ClearEnemy(rightAmmo,true);
            Dying();
            
        }
    }
}


