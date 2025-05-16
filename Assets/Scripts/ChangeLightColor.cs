using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// This script manages to change a light's color and the material color of a game object that represents the visual light
/// </summary>
public class ChangeLightColor : MonoBehaviour
{
    #region Properties
    /// <summary> The game object that represents the light </summary>
    [SerializeField] private GameObject _visualLight;

    /// <summary> The rednerer of the visual light </summary>
    private Renderer _visualLightRenderer;

    /// <summary> The light object </summary>
    [SerializeField] private Light _light;

    /// <summary> The initial color of the light </summary>
    [SerializeField] private Color _initialColor;

    /// <summary> The color the light and the game Object will be changed to </summary>
    [SerializeField] private Color _changedColor;

    #endregion

    #region Start
    private void Start()
    {
        _visualLightRenderer = _visualLight.GetComponent<Renderer>();
        SetInitialColor();
    }

    #endregion

    #region Methods
    public void SetInitialColor()
    {
        SetColor(_initialColor);
    }

    public void LightChangeColor()
    {
        SetColor(_changedColor);
    }

    /// <summary>
    /// Changes the light's color and the game object material color
    /// </summary>
    /// <param name="color"> The color that will be changed into </param>
    private void SetColor(Color color)
    {
        if (_visualLightRenderer != null)
        {
            Material mat = _visualLightRenderer.material;


            mat.color = color;
            mat.SetColor("_EmissionColor", color * 5f); 
        }

        if (_light != null)
        {
            _light.color = color;
        }
    }

    #endregion
}