using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Invoke("LoadFirstScene", 2f);
    }
	
	// Awake is called b4 Start()
	void Awake ()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
