using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{

    [Header("< 弹道相关参数 >")]
    public float bulletSpeed = 5;
    public int shootCount = 1;
    public float bulletFrequency = 100;
    public float shootFrequency = 100;
    public int penetrateCount = 0;
    public int diffractionCount = 0;

    [Header(" <暂存> ")]
    //public GameObject bulletPre = null;
    public int bulletID = 4001;
    public List<Enemy> targets = null;
    public Transform bulletPos = null;




    Trajactory shootTrajactory = null;

    private void Awake()
    {
        SetActive(false);
    }

    //private void Start()
    //{
    //    GameObject shootObj = SceneManager.Instance.effectManager.GetEffect(bulletID);
    //    shootObj.transform.SetParent(transform);
    //    shootObj.transform.localPosition = Vector3.zero;
    //    shootObj.transform.localEulerAngles = Vector3.zero;
    //    shootObj.transform.localScale = Vector3.one;
    //    shootTrajactory = shootObj.AddComponent<Trajactory>();
    //    shootTrajactory.Init(this, bulletSpeed, shootCount, bulletFrequency, shootFrequency);
    //    targets = SceneManager.Instance.enemyManager.enemyList;
    //    for(int i = 0; i < penetrateCount; i++)
    //    {
    //        AddPenetrateAbility();
    //    }

    //    for(int i = 0; i < diffractionCount; i++)
    //    {
    //        AddDiffractionAbility();
    //    }
    //}

    public void SetActive(bool active)
    {
        if (active && shootTrajactory == null)
        {
            GameObject shootObj = SceneManager.Instance.effectManager.GetEffect(bulletID);
            shootObj.transform.SetParent(transform);
            shootObj.transform.localPosition = Vector3.zero;
            shootObj.transform.localEulerAngles = Vector3.zero;
            shootObj.transform.localScale = Vector3.one;
            shootTrajactory = shootObj.AddComponent<Trajactory>();
            shootTrajactory.Init(this, bulletSpeed, shootCount, bulletFrequency, shootFrequency);
            targets = SceneManager.Instance.enemyManager.enemyList;
            for (int i = 0; i < penetrateCount; i++)
            {
                AddPenetrateAbility();
            }

            for (int i = 0; i < diffractionCount; i++)
            {
                AddDiffractionAbility();
            }
        }
        enabled = active;
    }

    public void Attack(bool ing)
    {
        if (ing)
        {
            if (!shootTrajactory.InShoot)
            {
                shootTrajactory.InShoot = true;
            }
        }
        else
        {
            if (shootTrajactory.InShoot)
            {
                shootTrajactory.InShoot = false;
            }
        }
    }


    public void SingleShot(Vector3 position, Vector3 targetPos)
    {
        shootTrajactory.Spwan(position, targetPos);
    }

    private void Update()
    {
        shootTrajactory.transform.position = bulletPos.position;
        Vector3 euler = bulletPos.rotation.eulerAngles;
        euler.x = 0;
        var rotaion = bulletPos.rotation;
        rotaion.eulerAngles = euler;
        shootTrajactory.transform.rotation = rotaion;
    }

    public void AddDiffractionAbility()
    {
        Trajactory t = shootTrajactory;
        while (t.dTrajactory != null)
        {
            t = t.dTrajactory;
        }
        GameObject shootObj = SceneManager.Instance.effectManager.GetEffect(bulletID);
        shootObj.transform.localPosition = Vector3.zero;
        shootObj.transform.localEulerAngles = Vector3.zero;
        t.dTrajactory = shootObj.AddComponent<Trajactory>();
        t.dTrajactory.Init(this, bulletSpeed, shootCount, bulletFrequency, shootFrequency);
    }

    public void AddPenetrateAbility()
    {
        Trajactory t = shootTrajactory;
        while (t.pTrajactory != null)
        {
            t = t.pTrajactory;
        }
        GameObject shootObj = SceneManager.Instance.effectManager.GetEffect(bulletID);
        shootObj.transform.localPosition = Vector3.zero;
        shootObj.transform.localEulerAngles = Vector3.zero;
        t.pTrajactory = shootObj.AddComponent<Trajactory>();
        t.pTrajactory.Init(this, bulletSpeed, shootCount, bulletFrequency, shootFrequency);
    }

    public void Stop()
    {
        shootTrajactory.system.Stop();
    }
}
