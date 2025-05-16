using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script activates and deactivates the emission property of a material
/// </summary>
public class BaseButtonBehavior : MonoBehaviour
{
    #region Properties

    /// <summary> The game object of the button </summary>
    [SerializeField] private GameObject _button;

    /// <summary> The renderer of the button to acces the material and the color </summary>
    private Renderer _buttonRenderer;

    #endregion

    #region Start

    private void Start()
    {
        _buttonRenderer = _button.GetComponent<Renderer>();
    }

    #endregion


    #region Methods

    /// <summary>
    /// Activates the emission property and sets the emission color as the same color the button has
    /// </summary>
    public void ActivateButtonColorEmission()
    {
        _buttonRenderer.material.EnableKeyword("_EMISSION");
        _buttonRenderer.material.SetColor("_EmissionColor", _buttonRenderer.material.color * 10f);
    }

    /// <summary>
    /// Deactivates the emission property of the material
    /// </summary>
    public void DeactivateButtonColorEmission()
    {
        _buttonRenderer.material.DisableKeyword("_EMISSION");
    }

    #endregion
}
