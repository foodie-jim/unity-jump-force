using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Prop_Barrier02;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(this.Prop_Barrier02, this.spawnPos, this.Prop_Barrier02.transform.rotation);
        this.playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", this.startDelay, this.repeatRate);
    }

    private void SpawnObstacles() {
        if (!this.playerControllerScript.gameOver) {
            Instantiate(this.Prop_Barrier02, spawnPos, this.Prop_Barrier02.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
