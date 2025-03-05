using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject model;
    public List<Color> colors;
    public Material material;

    private Color _defaultModelColor;
    private Color _defaultMaterialColor;
    private bool _hasColorChanged;
    private int _colorIndex = 0;

    void Start()
    {
        _defaultModelColor = model.GetComponent<Renderer>().material.color;
        _defaultMaterialColor = material.color;
        _colorIndex = -1;
    }

    public void DoChangeColor()
    {
        _colorIndex++;
        if (_colorIndex >= colors.Count)
        {
            model.GetComponent<Renderer>().material.color = _defaultModelColor;
            material.color = _defaultMaterialColor;
            _colorIndex = -1;
        }
        else
        {
            model.GetComponent<Renderer>().material.color = colors[_colorIndex];
            material.color = colors[_colorIndex];
        }
    }
}