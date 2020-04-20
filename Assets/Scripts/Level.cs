using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    //cached reference
    SceneLoader sceneLoader;

    public void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockBroken()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0) sceneLoader.LoadNextScene();
    }
}
