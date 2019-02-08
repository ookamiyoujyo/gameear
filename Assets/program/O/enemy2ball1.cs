using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2ball1 : MonoBehaviour
{
    public GameObject tama;
    private float targetTime = 1.0f;
    private float currentTime = 0;
    /*追記*/
    //飛ばすタイミングをはかるための変数
    //num=20で飛ばしています
    private int num = 0;
    /*追記終わり*/
    private float deg = 30;
    bool hasMakeTama = false;
    /*追記*/
    //弾オブジェクトについているスクリプト（TamaTobasu.cs）コンポネントを保存するためのリスト
    private List<TamaTobasu1> list = new List<TamaTobasu1>();
    /*追記終わり*/

    // Update is called once per frame
    void Update()
    {
        /*追記*/
        //弾を飛ばすまでのカウントを1進める
        num++;
        /*追記終わり*/
        if (!hasMakeTama)
        {
            var rad = deg * Mathf.Deg2Rad;
            var sin = Mathf.Sin(rad);
            var cos = Mathf.Cos(rad);
            var pos = gameObject.transform.position + new Vector3(cos * 0.5f, sin * 0.5f, sin * 0.5f);
            var t = Instantiate(tama) as GameObject;
            t.transform.position = pos;
            /*追記*/
            //弾オブジェクトtからTamaTobasuコンポネントを取得               
            var a = t.GetComponent<TamaTobasu1>();
            //取得したTamaTobasuコンポネントをlistに加える
            list.Add(a);
            //TamaTobasuスクリプト内のCharaPosにアクセスして中心座標をセットする
            a.CharaPos = gameObject.transform.position;
            //numカウントが20になったら弾を放射線状に飛ばす              
        }
        else if (num == 20)
        {
            //リストから一つずつ各弾オブジェクトのTamaTobasuコンポネントを取り出す
            foreach (var t in list)
            {
                //TamaTobasuコンポネント内のTobu()メソッドを実行
                t.Tobu();
            }
        }
        /*追記終わり*/
        deg += 30;
        if (deg == 180) deg += 30;
        if (deg == 360) hasMakeTama = true;
        if (hasMakeTama)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= targetTime)
            {
                num = 0;
                deg = 30;
                hasMakeTama = false;
                currentTime = 0;
                list.Clear();
            }
        }
    }
}