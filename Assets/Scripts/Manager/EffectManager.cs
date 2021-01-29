using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager
{
    EffectData effectData = null;
    Transform effectParent = null;

    public EffectManager(EffectData data,Transform parent)
    {
        effectData = data;
        effectParent = parent;
    }

    public GameObject GetEffect(int id)
    {
        EffectBase data = effectData.FindByID(id);
        GameObject effect = ObjectManager.Instance.InstantiateObject(data.PrefabPath);
        effect.transform.SetParent(effectParent);
        effect.SetActive(true);
        if(data.Duration > 0)
        {
            GameManager.Instance.mono.StartCoroutine(AutoRelease(effect, data.Duration));
        }
        return effect;
    }

    IEnumerator AutoRelease(GameObject effect,float time)
    {
        yield return new WaitForSeconds(time / 1000);
        ReleaseEffect(effect);
    }

    

    public void ReleaseEffect(GameObject effect)
    {
        ObjectManager.Instance.ReleaseObject(effect,recycleParent:false);
    }
}
