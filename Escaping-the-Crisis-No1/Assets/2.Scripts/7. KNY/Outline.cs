using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    private Material outlineMaterial;

    private Renderer renderers;
    List<Material> materialList = new List<Material>();

    void Start()
    {
        outlineMaterial = new Material(Shader.Find("Custom/Outline"));  
    }

    private void OnMouseDown()
    {
        renderers = this.GetComponent<Renderer>();

        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Add(outlineMaterial);

        renderers.materials = materialList.ToArray();
    }

        private void OnMouseUp()
    {
        renderers = this.GetComponent<Renderer>();

        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Remove(outlineMaterial);

        renderers.materials = materialList.ToArray();
    }

}
