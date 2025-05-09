using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class anime : MonoBehaviour
{
    public Animator animator;
    public GameObject PhysicBird;
    public float duration = 0.1f;
    private Coroutine rotating;
    public float rotationMultiplier = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateBird();

    }
    public void RotateBird()
    {
        if (rotating != null)
        {
            StopCoroutine(rotating);
        }
        rotating = StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        float time = 0f;
        float degree = 0f;
        float finaldegree = rotationMultiplier * PhysicBird.GetComponent<Rigidbody2D>().velocity.y;
        while (time < duration)
        {
            time += Time.deltaTime;
            degree = Mathf.Lerp(transform.rotation.z, finaldegree, time/duration);
            transform.rotation = Quaternion.Euler(0, 0, rotationMultiplier * degree);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, 0, finaldegree);
    }

    public void ChangeState(bool IsFly, bool canSim = false)
    {
        Rigidbody2D rd = PhysicBird.GetComponent<Rigidbody2D>();
        if (IsFly)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }
        rd.simulated = canSim;
        PhysicBird.GetComponent<birdFly>().enabled = canSim;
    }
}
