using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class GameCamera : MonoBehaviour
{
    public float smoothing = 5;
    public CinemachineVirtualCamera walkCamera;
    public CinemachineVirtualCamera inStageCamera;
    public CinemachineStateDrivenCamera drivenCamera;


    Transform followTarget = null;
    float shakeTimer = 0;
    CinemachineBasicMultiChannelPerlin shakePerlin;
    float startIntensity = 0;
    float shakeTimerTotal;

    private void Start()
    {
        shakePerlin = walkCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    //public void SetTarget(Transform target)
    //{
    //    if(target == null)
    //    {
    //        Debug.LogError("设置摄像机跟随对象为空，请检查！");
    //        return;
    //    }
    //    followTarget = target;
    //    walkCamera.Follow = followTarget;
    //    inStageCamera.LookAt = followTarget;
       
    //    //drivenCamera.State.AddCustomBlendable()

    //}

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            float res = Mathf.Lerp(0f,startIntensity, shakeTimer / shakeTimerTotal);
            shakePerlin.m_AmplitudeGain = res;
        }

    }

    public void ShakeCamera(float intensity,float time)
    {
        shakePerlin.m_AmplitudeGain = intensity;
        startIntensity = intensity;
        shakeTimer = time;
        shakeTimerTotal = time;
    }

}
