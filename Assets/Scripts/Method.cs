using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Method
{
    /// <summary>
    /// 判断是否在视野内
    /// </summary>
    /// <returns></returns>
    public static bool InSight(Transform src,Transform tar, float angle)
    {

        Vector3 dir = tar.position - src.position;
        return Vector3.Angle(src.forward, dir)<angle; 
    }
}
