using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ��ü���� Ȱ��� �� �ִ� enum, struct, const�� �����մϴ�.
public class Define
{
    public struct UIData
    {
        public string name;
        public GameObject gameObject;
        public UnityEngine.Object component;
    }

    public enum Scene
    {
        Awake, Main, Load, Select,
        Edu_A, Edu_B, Edu_C
    }

    public enum BGM
    {

    }

    public enum SFX
    {

    }
}
