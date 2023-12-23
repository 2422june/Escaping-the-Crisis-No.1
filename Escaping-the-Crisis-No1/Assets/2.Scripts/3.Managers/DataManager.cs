using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataForms;

public class DataManager : ManagerBase
{
    private List<DataForm> gameData = new List<DataForm>();

    public override void Init()
    {
        //gameData = Load<DataExamlple, DataForm>("DataExample");
    }

    private List<T> Load<Loader, T>(string path) where Loader : IDataForm<T>
    {
        TextAsset asset = Resources.Load<TextAsset>($"Data/{path}");
        Loader form = JsonUtility.FromJson<Loader>(asset.text);
        return form.GetList();
    }

    public List<DataForm> GetExampleData()
    {
        return gameData;
    }
}
