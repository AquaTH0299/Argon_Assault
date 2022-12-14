using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReLoadLevel", loadDelay);
    }

    void ReLoadLevel()
    {
        int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneindex);
    }
}