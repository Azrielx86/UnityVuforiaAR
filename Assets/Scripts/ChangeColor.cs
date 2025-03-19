using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");
    public GameObject model;
    public Material material;

    public List<Texture> textures;

    private Color _defaultModelColor;
    private Texture _defaultModelTexture;
    private Color _defaultMaterialColor;
    private bool _hasColorChanged;

    void Start()
    {
        _defaultModelTexture = model.GetComponent<Renderer>().material.mainTexture;
        _defaultMaterialColor = material.color;
    }

    public void RestoreMaterials()
    {
        model.GetComponent<Renderer>().material.SetTexture(MainTex, _defaultModelTexture);
        material.color = _defaultMaterialColor;
    }
    
    public void DoChangeColor()
    {
        material.color = GenerateRandomColor(Color.white, 0.8f);
        var newTex = textures[Random.Range(0, textures.Count)];
        model.GetComponent<Renderer>().material.SetTexture(MainTex, newTex);
    }

    private static Color GenerateRandomColor(Color mix, float mixRatio)
    {
        var randRed = Random.Range(0, 256);
        var randGreen = Random.Range(0, 256);
        var randBlue = Random.Range(0, 256);

        var red = (randRed + mix.r) * mixRatio;
        var green = (randGreen + mix.g) * mixRatio;
        var blue = (randBlue + mix.b) * mixRatio;

        return new Color(red / 256.0f, green / 256.0f, blue / 256.0f);
    }
}