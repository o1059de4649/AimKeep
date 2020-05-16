using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ReSpawnBall : MonoBehaviour
{
    public GameObject aim_ball;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ボール生成
    /// </summary>
    public void SpawnBall() 
    {
        float _x = this.transform.position.x + Random.Range(-this.transform.localScale.x * 5, this.transform.localScale.x * 5);
        float _z = this.transform.position.z + Random.Range(-this.transform.localScale.z * 5, this.transform.localScale.z * 5);
        var _position = new Vector3(_x
            , Random.Range(0.5f,2.0f)
            , _z);
        GameObject obj = Instantiate(aim_ball,_position,Quaternion.identity);
    }
}
