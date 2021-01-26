using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public RectTransform knob;
    public RectTransform safeArea;
    public RectTransform moveArea;
    private Canvas canvas;

    private bool inShow = true;
    private float homingSmooth = 0.5f;
    public float range = 5;

    [HideInInspector]
    public Vector3 movement;



    // Start is called before the first frame update
    void Start()
    {
        canvas = RFramework.Instance.m_UIRoot.GetComponent<Canvas>();
        movement = new Vector3();
        ShowHide(false);
    }

    // Update is called once per frame
    private Vector3 fix = new Vector3();
    void Update()
    {
        Smooth();
        BaseInput input = RFramework.Instance.m_UIEventSystem.currentInputModule.input;
        Vector2 worldPos = RFramework.Instance.m_UICamera.ScreenToWorldPoint(input.mousePosition);
        Vector3 uiPos = canvas.transform.InverseTransformPoint(worldPos);
        if (!inShow && input.GetMouseButtonDown(0))
        {
            moveArea.position = moveArea.localToWorldMatrix * uiPos;
            fix.Set(uiPos.x, uiPos.y, uiPos.z);
            ShowHide(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            ShowHide(false);
        }        

        if (inShow)
        {
            Vector3 off = uiPos -  fix;
            float dis = Vector3.SqrMagnitude(off);
            float radius = moveArea.rect.width * 0.5f;
            float safeRadius = safeArea.rect.width * 0.5f;
            if (dis<=radius* radius)
            {
                knob.position = knob.localToWorldMatrix * uiPos;
            }
            else
            {
                knob.position = knob.localToWorldMatrix * fix;
                knob.localPosition += off.normalized * radius;
            }
            if (Vector3.SqrMagnitude(knob.localPosition) >= safeRadius * safeRadius)
            {
                movement.x = knob.localPosition.x / (moveArea.rect.width * 0.25f);
                movement.z = knob.localPosition.y / (moveArea.rect.height * 0.25f);
            }
        }
    }

    public void ShowHide(bool state)
    {
        moveArea.gameObject.SetActive(state);
        inShow = state;
    }

    void Smooth()
    {
        if(movement.x != 0)
        {
            movement.x *= homingSmooth;
            if (Mathf.Abs(movement.x) < 0.05f)
            {
                movement.x = 0;
            }
        }

        if (movement.z != 0)
        {
            movement.z *= homingSmooth;
            if (Mathf.Abs(movement.z) < 0.05f)
            {
                movement.z = 0;
            }
        }
    }

}
