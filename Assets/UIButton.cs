using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct UIButton
{
    [SerializeField] private Button buttonUI;
    
    [SerializeField] private string valueToType;

    public Button ButtonUI => buttonUI;

    public string ValueToType => valueToType;
}