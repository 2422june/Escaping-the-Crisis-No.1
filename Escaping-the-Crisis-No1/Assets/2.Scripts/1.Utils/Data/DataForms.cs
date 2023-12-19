using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class DataForms
{
    public interface IDataForm<T>
    {
        public List<T> GetList();
    }

    [System.Serializable]
    public class DataForm
    {
        public int id;
        public string intro;
    }

    [System.Serializable]
    public class DataExamlple : IDataForm<DataForm>
    {
        public List<DataForm> datas = new List<DataForm>();

        public List<DataForm> GetList()
        {
            return datas;
        }
    }
}
