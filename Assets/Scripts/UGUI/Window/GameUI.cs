using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : Window
{
    public GamePanel m_Panel;

    private List<GameObject> balls = new List<GameObject>();




    public override void OnAwake(params object[] paraList)
    {
        m_Panel = GameObject.GetComponent<GamePanel>();
        AddBtnClickListener(m_Panel.homeBtn, ClickHomeBtn);
        AddBtnClickListener(m_Panel.createBall, ClickAddBallBtn);
        AddBtnClickListener(m_Panel.clearBall, ClearBalls);

        m_Panel.ballNum.text = balls.Count.ToString();
    }

    

    public override void OnClose()
    {
        base.OnClose();
        ClearBalls();
        m_Panel.joystick.ShowHide(false);
    }

    void ClickHomeBtn()
    {
        UIManager.Instance.CloseWindow(Name);
        GameMapManager.Instance.LoadScene(ConStr.MENUSCENE, 1);
    }

    void ClickAddBallBtn()
    {
        //EnemyManager.Instance.Spwan(2001);
    }

    void ClearBalls()
    {
        foreach (GameObject ball  in balls)
        {
            ObjectManager.Instance.ReleaseObject(ball);
        }
        balls.Clear();
        m_Panel.ballNum.text = balls.Count.ToString();
    }
}


