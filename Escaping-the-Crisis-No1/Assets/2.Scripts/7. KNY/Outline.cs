using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//물체의 아웃라인에 선을 그려주는 스크립트
//아웃라인을 그려주고 싶은 오브젝트에 해당 스크립트 할당
public class Outline : MonoBehaviour
{
    //아웃라인이 생성되는 메테리얼
    private Material outlineMaterial;

    //렌더러 컴포넌트
    private Renderer renderers;
    //메테리얼 리스트
    List<Material> materialList = new List<Material>();

    void Start()
    {
        //아웃라인을 생성해주는 쉐이더로 메테리얼 생성하여 할당
        outlineMaterial = new Material(Shader.Find("Custom/Outline")); 
        renderers = this.GetComponent<Renderer>(); 
    }

    //아웃라인을 그려주는 함수. ps. 아웃라인 그리고 싶을 때 이 함수 호출하기!
    public void DrawOutline()
    {
        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Add(outlineMaterial);

        renderers.materials = materialList.ToArray();
    }

    //아웃라인을 제거하는 함수. ps. 아웃라인 제거할 때 이 함수 호출하기!
    public void RemoveOutline()
    {
        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Remove(outlineMaterial);

        renderers.materials = materialList.ToArray();
    }

}
