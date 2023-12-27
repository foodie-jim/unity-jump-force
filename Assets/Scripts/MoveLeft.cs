using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        this.playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.playerControllerScript.gameOver) {
        
            this.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
        }

        if (this.transform.position.x < this.leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
