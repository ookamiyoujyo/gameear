using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdelete : MonoBehaviour {

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "area")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
