using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dameji1 : MonoBehaviour {
    int dame = 0;

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "playerdamage")
        {
            dame++;
            if (dame == 50)
            {
                Destroy(gameObject);
            }
        }
    }
}