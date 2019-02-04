using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "area")
        {
            Destroy(gameObject);
        }
    }
}
