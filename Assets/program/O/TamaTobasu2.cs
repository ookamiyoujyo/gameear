using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaTobasu2 : MonoBehaviour {

    //中心座標
    private Vector3 charaPos;
    //charaPosに中心座標をセット（SetTama.csで呼び出してセットしています）
    public Vector3 CharaPos { set { charaPos = value; } }
    //弾自身体の座標をセットする変数
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {
        //弾の始点をセット（SetTama.csで始点に置いているので自分自身の位置を取得するだけ）
        pos = gameObject.transform.position;
    }

    /**
     * 弾を飛ばす
     */
    public void Tobu()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(pos.x - charaPos.x, pos.y - charaPos.y, 0);
    }
}