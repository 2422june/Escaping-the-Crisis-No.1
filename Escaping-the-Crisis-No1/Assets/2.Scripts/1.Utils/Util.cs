using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Find, GetOrAddComponent �� ������ ����� �����մϴ�.
public static class Util
{
    public static T GetOrAddComponent<T>(GameObject target) where T : Component
    {
        T component = target.GetComponent<T>();
        if(component == null)
        {
            component = target.AddComponent<T>();
        }
        return component;
    }

    private static Transform _root = null;

    public static GameObject Find(string target)
    {
        GameObject go = null;
        Transform tr = null;

        go = GameObject.Find(target);

        if (go == null)
            tr = _root.Find(target);
        else
            return go;

        if (tr == null)
        {
            for (int i = 0; i < _root.childCount; i++)
            {
                tr = _root.GetChild(i).Find(target);
            }
        }

        if (tr == null)
        {
            Debug.LogError("No Object");
            return null;
        }

        return tr.gameObject;
    }

    public static void SetRoot(Transform root) { _root = root; }

    public static void SetRoot(GameObject root) { _root = root.transform; }

    public static void SetRoot(string root, bool recursive = false)
    {
        _root = null;
        if (!recursive)
        {
            _root = GameObject.Find(root).transform;
        }
        else
        {
            _root = Find(root).transform;
        }

        if(_root == null)
        {
            Debug.LogError("Can't Find Object");
        }
    }

    public static GameObject GetRoot()
    {
        return _root.gameObject;
    }

    public static T Load<T>(string path) where T : UnityEngine.Object
    {
        T go = Resources.Load<T>(path);
        return go;
    }

    public static T[] Loads<T>(string path) where T : UnityEngine.Object
    {
        T[] go = Resources.LoadAll<T>(path);
        return go;
    }
}
