using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipe;
    public Transform pipes;
    public float waittime = 2f;
    public bool canCreatePipes = false;
    List<GameObject> pipeList = new List<GameObject>();

    public void Start()
    {
        StartCoroutine(CreatePipe());
    }
    public void PipeMove() {
        foreach (GameObject pipe in pipeList) {
            pipe.GetComponent<PipeScript>().canMove = true;
        }
        canCreatePipes = true;
    }

    public void PipeStop() {
        foreach (GameObject pipe in pipeList) {
            pipe.GetComponent<PipeScript>().canMove = false;
        }
        canCreatePipes = false;
    }

    IEnumerator CreatePipe()
    {
        while (true)
        {
            yield return new WaitForSeconds(waittime);
            if (!canCreatePipes) continue;
            GenerateOnePipe();           
        }
    }

    public void GenerateOnePipe()
    {
        GameObject newpipe = GameObject.Instantiate(pipe, pipes);
        newpipe.GetComponent<PipeScript>().RandomHeight();
        pipeList.Add(newpipe);
    }

    public void Update() {
        for(int i = pipeList.Count - 1; i >= 0; i--) {
            if (pipeList[i].transform.position.x < -4) {
                Destroy(pipeList[i]);
                pipeList.RemoveAt(i);
            }
        }

    }
}
