using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// スコア
    /// </summary>
    public int score;
    /// <summary>
    /// 射撃数
    /// </summary>
    public int shooting;
    public Text score_text;
    public Text timer_text;
    public Text sence_slider_text;
    /// <summary>
    /// 制限時間
    /// </summary>
    public float timer;
    public float maxtimer;
    // Start is called before the first frame update
    void Start()
    {
        maxtimer = timer;
    }
    public Slider speed_slider;

    // Update is called once per frame
    void Update()
    {
        if (score <= 0) return;
        timer -= Time.deltaTime;
        if (timer > 0) 
        {
            SetText();
        }
    }

    public void SetText() 
    {
        var sb = new StringBuilder();
        sb.AppendLine($"撃破数:{score}");
        sb.AppendLine($"撃破速度:{Math.Round((float)score/(maxtimer - timer),1)}/s");
        sb.AppendLine($"命中率:{Math.Round((((float)score / (float)shooting) * 100),1)}%");
        score_text.text = sb.ToString();
        timer_text.text = Mathf.Floor(timer).ToString();
    }

    /// <summary>
    /// 設定保存
    /// </summary>
    public void SetSave()
    {
        PlayerPrefs.SetFloat("SPEED", speed_slider.value);
    }
}
