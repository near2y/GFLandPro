using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProp
{
    public ParticleSystem system;
    ParticleSystem.MainModule main;
    public ParticleSystem.EmissionModule emission;
    public ParticleSystem.Burst[] bursts;


    public BulletProp(ParticleSystem particleSystem)
    {
#if UNITY_EDITOR
        if (particleSystem == null)
        {
            Debug.LogError("粒子对象为空，请检查！");
        }
#endif
        system = particleSystem;
        main = system.main;
        emission = system.emission;
        bursts = new ParticleSystem.Burst[emission.burstCount];
    }

    // 子弹飞行速度
    float bulletSpeed = 0;
    public float BulletSpeed
    {
        get { return bulletSpeed; }
        set
        {
            bulletSpeed = value;
            main.startSpeed = bulletSpeed;
        }
    }

    //循环 
    public bool Loop
    {
        get { return main.loop; }
        set
        {
            main.loop = value;
        }
    }

    //发射一次放出的子弹数量
    int shootCount = 0;
    public int ShootCount
    {
        get { return shootCount; }
        set
        {
            shootCount = value;
            emission.GetBursts(bursts);
            bursts[0].cycleCount = shootCount;
            emission.SetBursts(bursts);
        }
    }

    // 子弹射击间隔,单位毫秒
    float bulletFrequency = 0;
    public float BulletFrequency
    {
        get { return bulletFrequency; }
        set
        {
            bulletFrequency = value;
            if (value <= 0) return;
            emission.GetBursts(bursts);
            bursts[0].repeatInterval = bulletFrequency/1000;
            emission.SetBursts(bursts);
        }
    }

    // 每次发射中间间隔,单位毫秒
    float shootFrequency = 0;
    public float ShootFrequency
    {
        get { return shootFrequency; }
        set
        {
            shootFrequency = value;
            float duration = shootFrequency + (shootCount - 1) * bulletFrequency;
            main.duration = duration / 1000;
        }
    }

}
