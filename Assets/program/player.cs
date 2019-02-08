using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private float targetTime = 0.5f;
    private float currentTime = 0;

    bool hasMakeTama = false;

    int a = 1, i = 0;
    // bullet prefab
    public GameObject bullet;
    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public float speed = 1000;
    private float timeleft;

    void Update()
    {
        // z キーが押された時
        if (Input.GetKey(KeyCode.Space))
        {
            currentTime += Time.deltaTime;
            if (currentTime >= targetTime)
            {
                hasMakeTama = true;
                currentTime = 0;
            }
            if (hasMakeTama)
            {
                timeleft -= Time.deltaTime;
                if (timeleft <= 0.0)
                {
                    timeleft = 0.1f;
                    // 弾丸の複製
                    GameObject bullets = Instantiate(bullet) as GameObject;

                    Vector3 force;

                    force = this.gameObject.transform.forward * speed;

                    // Rigidbodyに力を加えて発射
                    bullets.GetComponent<Rigidbody>().AddForce(force);

                    // 弾丸の位置を調整
                    bullets.transform.position = muzzle.position;
                }
            }
        }
        else
        {
            hasMakeTama = false;
        }
    }
}
