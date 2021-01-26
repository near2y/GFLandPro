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
        return effect;
    }

    public void ReleaseEffect(GameObject effect)
    {
        ObjectManager.Instance.ReleaseObject(effect,recycleParent:false);
    }
}
