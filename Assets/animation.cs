using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private Animator test;
    // Use this for initialization
    void Start()
    {
        test = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            test.SetFloat("tama", 0);
        }
        else
        {
            test.SetFloat("tama", 0.1f);
        }


    }
}
