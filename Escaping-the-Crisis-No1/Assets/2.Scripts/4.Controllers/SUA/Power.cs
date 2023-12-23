using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Interactable
{

    SUA_B root;
    public void Init(SUA_B b)
    {
        root = b;
    }

    int count;
    public override void OnClick()
    {
        GetComponent<Outline>().RemoveOutline();
        root.Next();
    }
}
