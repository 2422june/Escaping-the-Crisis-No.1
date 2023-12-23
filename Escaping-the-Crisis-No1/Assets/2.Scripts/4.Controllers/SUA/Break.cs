using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : Interactable
{
    SUA_B root;
    public void Init(SUA_B b)
    {
        root = b;
    }

    int count;
    public override void OnClick()
    {
        count++;
        if(count > 2)
        {
            GetComponent<Outline>().RemoveOutline();
            root.Next();
        }
    }
}
