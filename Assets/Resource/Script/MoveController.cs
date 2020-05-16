using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    public GameController gameController;
    public ReSpawnBall reSpawn;
    const string _speed_text = "SPEED";
    public float speed 
    {
        get { 
            gameController.sence_slider_text.text = $"感度:{speed_slider.value}";
            return _speed; }
        set {
            _speed = value; }
    }
    private float _speed;
    public Slider speed_slider => gameController.speed_slider;

    // Start is called before the first frame update
    void Start()
    {
        speed = (PlayerPrefs.HasKey(_speed_text)) ? PlayerPrefs.GetFloat(_speed_text): 1 ;
        speed_slider.value = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float right_hori = Input.GetAxis("3rd axis");
        float right_vert = Input.GetAxis("6th axis");
        this.transform.eulerAngles += new Vector3(-right_vert * speed,right_hori * speed);
        //R2で射撃
        if (Input.GetKeyDown("joystick button 7"))
        {
            Shoot();
        }
        //DebugController();
    }

    /// <summary>
    /// 射撃
    /// </summary>
    public void Shoot() 
    {
        gameController.shooting++;
        Ray ray = new Ray(Camera.main.transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //ボールに命中したら
            if (hit.transform.gameObject.tag == "Ball") 
            {
                //削除
                gameController.score++;
                Destroy(hit.transform.gameObject);
                reSpawn.SpawnBall();
            }
        }
    }

    /// <summary>
    /// 検証用
    /// </summary>
    public void DebugController() 
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("button0");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("button1");
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("button2");
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("button3");
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("button4");
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("button5");
        }
        if (Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("button6");
        }
        if (Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("button7");
        }
        if (Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("button8");
        }
        if (Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("button9");
        }
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if ((hori != 0) || (vert != 0))
        {
            Debug.Log("stick:" + hori + "," + vert);
        }

        float right_hori = Input.GetAxis("3rd axis");
        float right_vert = Input.GetAxis("6th axis");
        if ((right_hori != 0) || (right_vert != 0))
        {
            Debug.Log("right_stick:" + right_hori + "," + right_vert);
        }
    }
}
