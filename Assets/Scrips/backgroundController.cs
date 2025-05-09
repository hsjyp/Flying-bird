using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class backgroundController : MonoBehaviour
{
    Vector3 startPos;
    public float speed  = -0.005f;
    public float offset  = 0f;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        transform.Translate(speed, 0, 0);
        if (transform.position.x < -2.8 - offset)
        {
            transform.transform.position = startPos;
        }
    }
}
