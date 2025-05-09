using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFly : MonoBehaviour
{
    public Rigidbody2D rd;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fly();
        }
    }
    public void Fly()
    {
        rd.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
    }
}
