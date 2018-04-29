using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    ScoreBoard scoreBoard;
    [SerializeField] int scoreHit = 10;    // How much the score goes up each time

    void Start () {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scoreHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); // drop a death FX prefab in the worl
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
