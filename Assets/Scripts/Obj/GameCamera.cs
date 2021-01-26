using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public float smoothing = 5;


    Transform followTarget = null;
    Vector3 offSet;
    bool couldFollow = false;


    public void SetTarget(Transform target)
    {
        if(target == null)
        {
            Debug.LogError("设置摄像机跟随对象为空，请检查！");
            return;
        }
        couldFollow = true;
        followTarget = target;
        offSet = followTarget.position - transform.position;
    }



    private void FixedUpdate()
    {
        if (couldFollow)
        {
            Vector3 targetPos = followTarget.position - offSet;
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
        }
    }

}
