using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float speed = 0.03f;
    public bool canMove;

    void Start() {
        canMove = true;
    }
    public void RandomHeight()
    {
        float height = Random.Range(-1f, 0.5f);
        Vector3 position = transform.position;
        position.y = height;
        transform.position = position;
    }
    public void FixedUpdate()
    {
        if (!canMove) return;
        transform.Translate(-speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        GetComponent<Collider2D>().enabled = false;
    }
}
