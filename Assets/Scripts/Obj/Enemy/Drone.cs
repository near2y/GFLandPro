using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Enemy
{
    //[Header("< 无人机相关设置 >")]
    //public 

    [HideInInspector]
    public int id_SpwanType = Animator.StringToHash("SpwanType");


    public override void InStage(Transform target, Transform spwanPoint)
    {

        Init(target, spwanPoint);

        //登场方式
        if (spwanPoint.tag == SpwanPointTag.Climb)
        {
            //从地下飞上来的
            anim.SetFloat(id_SpwanType, 1);
        }
        else if (spwanPoint.tag == SpwanPointTag.Full)
        {
            //落下来的
            anim.SetFloat(id_SpwanType, 0);
        }
        //从哪一帧开始播放登场动画
        anim.Play(EnemyState.InStage);
    }

    private void OnParticleCollision(GameObject other)
    {
        hp -= SceneManager.Instance.player.ATK;
        OnHit();
        if (hp <= 0 && !died)
        {
            Dying();
        }
    }

}
