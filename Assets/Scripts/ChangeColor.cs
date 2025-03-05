using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject model;
    public Color color;
    public Material material;

    private Color _defaultModelColor;
    private Color _defaultMaterialColor;
    private bool _hasColorChanged;

    void Start()
    {
        _defaultModelColor = model.GetComponent<Renderer>().material.color;
        _defaultMaterialColor = material.color;
        _hasColorChanged = false;
    }

    public void DoChangeColor()
    {
        if (_hasColorChanged)
        {
            model.GetComponent<Renderer>().material.color = _defaultModelColor;
            material.color = _defaultMaterialColor;
            _hasColorChanged = false;
        }
        else
        {
            model.GetComponent<Renderer>().material.color = color;
            material.color = color;
            _hasColorChanged = true;
        }
    }
}