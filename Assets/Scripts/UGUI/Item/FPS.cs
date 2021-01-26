using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    float time;
    int frameCount;
    Text fpsText;
    // Start is called before the first frame update
    void Start()
    {
        fpsText = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.unscaledDeltaTime;
        frameCount++;
        if (time >= 1 && frameCount >= 1)
        {
            float fps = frameCount / time;
            time = 0;
            frameCount = 0;
            fpsText.text = "FPS:"+ fps.ToString();//#0.00
            fpsText.color = fps >= 20 ? Color.white : (fps > 15 ? Color.yellow : Color.red);
        }
    }
}
