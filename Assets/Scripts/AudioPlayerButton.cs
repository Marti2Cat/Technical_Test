using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
///  Makes a call to the audio manager script to play an audio
/// </summary>
public class AudioPlayerButton : MonoBehaviour
{
    #region Properties

    /// <summary> The game object that has got the audio source property and the audiomanager script </summary>
    [SerializeField] private GameObject _audioManagerObject;

    /// <summary> A reference to the audio manager script </summary>
    private AudioManager _audioManager;

    /// <summary> The audio that will be played </summary>
    [SerializeField] private AudioClip _audioToPlay;


    #endregion

    #region Start
    private void Start()
    {
        _audioManager = _audioManagerObject.GetComponent<AudioManager>();
    }

    #endregion


    #region Methods

    /// <summary>
    /// Calls the audio manager script to play this audio
    /// </summary>
    public void PlayAudio()
    {
        _audioManager.PlayAudio(_audioToPlay);
    }

    #endregion
}
