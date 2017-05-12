using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SdsuBuildingCollisionDetector : MonoBehaviour
{
    public GameObject gameObject;

    // Use this for initialization
    void Start()
    {
        gameObject = GameObject.FindWithTag("SDSUBuilding");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Particle hit!");
        ScoreboardUpdate.particleBoxColliderRemover(other);
        ScoreboardUpdate.BoardUpdater(gameObject);
    }
}