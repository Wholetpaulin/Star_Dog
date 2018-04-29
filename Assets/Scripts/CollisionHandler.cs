using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // This is ok ALA this is the only script that loads scenes

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        explosion.SetActive(true);
        Invoke("ResetScene", levelLoadDelay);// reload level 1 with a configurable delay
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(1);
    }
}
