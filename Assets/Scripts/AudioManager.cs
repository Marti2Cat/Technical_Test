using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages all the audios in scene
/// </summary>
public class AudioManager : MonoBehaviour
{
    #region Properties

    /// <summary> The audio source component in this game object </summary>
    private AudioSource _audioSource;

    #endregion

    #region Start
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Plays an audio
    /// </summary>
    /// <param name="clip"> The audioclip that will be played </param>
    public void PlayAudio(AudioClip clip)
    {

        _audioSource.PlayOneShot(clip);
    }

    #endregion
}
