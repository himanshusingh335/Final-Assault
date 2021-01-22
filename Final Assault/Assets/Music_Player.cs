using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Player : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<Music_Player>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke("LoadFirstScene", 3f);
        
    }

    // Update is called once per frame
    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
