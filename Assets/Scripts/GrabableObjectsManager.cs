using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the spawn and destroy events of the grabable objects
/// </summary>
public class GrabableObjectsManager : MonoBehaviour
{
    #region Properties

    /// <summary> The prefab that contains the grabable objects </summary>
    [SerializeField] private GameObject _grabableObjectsPrefab;

    /// <summary> The void gameObject that defines the spawn position of the objects </summary>
    [SerializeField] private GameObject _objectsSpawnPosition;

    /// <summary> An instance of the objects prefab </summary>
    private GameObject _objectInstance;

    #endregion

    #region Start
    private void Start()
    {
        SpawnObjects();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Spawns the prefab instance of the grabable objects
    /// </summary>
    public void SpawnObjects()
    {
        _objectInstance = Instantiate(_grabableObjectsPrefab,_objectsSpawnPosition.transform.position ,Quaternion.Euler(0,0,0));
    }

    /// <summary>
    /// Destroys the instance active in the scene
    /// </summary>
    public void DestroyGrabableObjects()
    {
        Destroy(_objectInstance);
    }

    #endregion
}
