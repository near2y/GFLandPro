using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan : Enemy
{
    public TitanAttackType attackType = TitanAttackType.Beat;
    public override void InStage(Transform target, Transform spwanPoint)
    {
        Init(target, spwanPoint);
        //攻击类型
        
        ////登场方式
        //if (spwanPoint.tag == SpwanPointTag.Climb)
        //{
        //    //爬上来的
        //    anim.SetFloat(id_SpwanType, 1);
        //    //从哪一帧开始播放登场动画
        //    anim.Play(EnemyState.InStage, 0, Random.Range(startRange.x, startRange.y));
        //}
        //else if (spwanPoint.tag == SpwanPointTag.Full)
        //{
        //    //落下来的
        //    anim.SetFloat(id_SpwanType, 0);
        //    anim.Play(EnemyState.InStage);
        //}
    }
}

public enum TitanAttackType 
{
    Beat,
    Shoot
}

