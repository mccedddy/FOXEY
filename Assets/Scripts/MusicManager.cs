using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;
    private void Update()
    {
        // If level starts, stop menu music
        if (SceneManager.GetActiveScene().name == "Stage1" ||
            SceneManager.GetActiveScene().name == "Stage2" ||
            SceneManager.GetActiveScene().name == "Stage3")
        {
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        // Dont destroy music on switching scenes
        DontDestroyOnLoad(transform.gameObject);

        if (musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
