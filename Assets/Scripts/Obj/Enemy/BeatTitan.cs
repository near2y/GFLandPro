using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTitan : Enemy
{
    [HideInInspector]
    public int id_AttackType = Animator.StringToHash("AttackType");

    public GameObject effectPre = null;
    public Transform effectPos = null;

    private void Start()
    {
        if (effectPos == null) effectPos = transform;
    }

    public override void InStage(Transform target, Transform spwanPoint)
    {
        Init(target, spwanPoint);

        //登场
        anim.Play(EnemyState.InStage);

        //攻击类型
        anim.SetFloat(id_AttackType, 0);

    }

    void ShowEffect(int effectID)
    {
        GameObject effect = SceneManager.Instance.effectManager.GetEffect(effectID);
        effect.transform.position = effectPos.position;
        effect.transform.rotation = effectPos.rotation;
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
