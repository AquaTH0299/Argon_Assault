using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 7;
    [SerializeField] int hitPoints = 2;
    ScoreBoard scoreBoard;
    GameObject parentgameObject;
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentgameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigibody();
    }
    void AddRigibody()
    {
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
    }
    void OnParticleCollision(GameObject other)
    {
        processHit(); 
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }
    private void processHit()
    {
        hitPoints--;
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentgameObject.transform;
    }
    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentgameObject.transform;
        Destroy(gameObject);
    }
}