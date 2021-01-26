using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajactory : MonoBehaviour
{
    public ParticleSystem system;
    public BulletProp bulletProp = null;
    //发射器
    public Emitter test;
    public Trajactory pTrajactory= null;
    public Trajactory dTrajactory = null;

    List<ParticleCollisionEvent> collisionEvents;
    

    private void Awake()
    {
        system = GetComponent<ParticleSystem>();
#if UNITY_EDITOR
        if (system == null)
        {
            Debug.LogError("对象：" + gameObject.name + "  没有粒子系统，检查！");
        }
#endif
        bulletProp = new BulletProp(system);
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        if (bulletProp == null)
        {
            Debug.LogError("对象：" + gameObject.name + "  没有初始化bulletProp,检查！");
        }
#endif
    }

    public void Init(Emitter emitter, 
        float bulletSpeed,int shootCount,float bulletFrequency,float shootFrequency)
    {
        test = emitter;
        bulletProp.BulletSpeed = bulletSpeed;
        bulletProp.ShootCount = shootCount;
        bulletProp.BulletFrequency = bulletFrequency;
        bulletProp.ShootFrequency = shootFrequency;
    }

    bool inPlay = false;
    public bool InShoot
    {
        set
        {
            inPlay = value;
            if (inPlay)
            {
                system.Play();
            }
            else
            {
                system.Stop();
            }
        }
        get { return inPlay; }
    }

    public void Spwan(Vector3 position,Vector3 targetPos)
    {
        system.Stop();
        bulletProp.Loop = false;
        transform.position = position;
        transform.LookAt(targetPos);
        Vector3 euler = transform.rotation.eulerAngles;
        euler.x = 0;
        var rotaion = transform.rotation;
        rotaion.eulerAngles = euler;
        transform.rotation = rotaion;
        system.Play();
    }

    private void OnParticleCollision(GameObject other)
    {

        Diffraction(other);
        Penetrate(other);
    }

    //弹射
    void Diffraction(GameObject other)
    {
        if (dTrajactory == null || test.targets.Count<2) return;
        Collider collider = other.GetComponent<Collider>();
        int t = Random.Range(0, test.targets.Count);
        float dis = Mathf.Max(collider.bounds.size.x, collider.bounds.size.z) * 0.6f;
        Vector3 point = other.transform.position + (test.targets[t].transform.position - other.transform.position).normalized * dis;
        dTrajactory.Spwan(point, test.targets[t].transform.position);
    }

    //穿透
    void Penetrate(GameObject other)
    {
        if (pTrajactory == null ) return;
        int numCollisionEvents = system.GetCollisionEvents(other, collisionEvents);
        Collider collider = other.GetComponent<Collider>();
        float dis = Mathf.Max(collider.bounds.size.x, collider.bounds.size.z) * 0.6f;
        for(int i = 0; i < numCollisionEvents; i++)
        {
            Vector3 point = other.transform.position + collisionEvents[i].velocity.normalized * dis;
            Vector3 penetratePos = point + collisionEvents[i].velocity.normalized * dis;
            pTrajactory.Spwan(point, penetratePos);
        }
    }
}
