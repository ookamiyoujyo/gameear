using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2ball : MonoBehaviour
{
    public GameObject tama;
    private float targetTime = 1.0f;
    private float currentTime = 0;
    /*追記*/
    //飛ばすタイミングをはかるための変数
    //num=20で飛ばしています
    private int num = 0;
    /*追記終わり*/
    private float deg = 0;
    bool hasMakeTama = false;
    /*追記*/
    //弾オブジェクトについているスクリプト（TamaTobasu.cs）コンポネントを保存するためのリスト
    private List<ball2> list = new List<ball2>();
    /*追記終わり*/

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0;
            /*追記*/
            //弾を飛ばすまでのカウントを1進める
            num++;
            /*追記終わり*/
            if (!hasMakeTama)
            {
                var rad = deg * Mathf.Deg2Rad;
                var sin = Mathf.Sin(rad);
                var cos = Mathf.Cos(rad);
                var pos = this.gameObject.transform.position + new Vector3(cos * 2.0f, sin * 2.0f, 0);
                var t = Instantiate(tama) as GameObject;
                t.transform.position = pos;
                /*追記*/
                //弾オブジェクトtからTamaTobasuコンポネントを取得               
                var a = t.GetComponent<ball2>();
                //取得したTamaTobasuコンポネントをlistに加える
                list.Add(a);
                //TamaTobasuスクリプト内のCharaPosにアクセスして中心座標をセットする
                a.CharaPos = this.gameObject.transform.position;
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
            if (deg == 330) hasMakeTama = true;
        }
    }
}
