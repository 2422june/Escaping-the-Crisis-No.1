using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBar : MonoBehaviour
{
    SUA_B root;
    public void Init(SUA_B b)
    {
        root = b;
    }

    void Update()
    {
        if(transform.rotation.x >= -60)
        {
            root.Next();
        }
    }
}
