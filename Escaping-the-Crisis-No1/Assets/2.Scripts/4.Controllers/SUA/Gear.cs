using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    SUA_B root;
    public void Init(SUA_B b)
    {
        root = b;
    }

    void Update()
    {
        if(transform.position.z >= 1.6f && transform.position.z >= 2.8f)
        {
            root.Next();
        }
    }
}
