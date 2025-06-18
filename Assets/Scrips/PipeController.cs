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
    Stack<GameObject> pipePool = new Stack<GameObject>();
    Vector3 generatePositon = Vector3.zero;

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
        GameObject newpipe;
        if (pipePool.Count != 0) {
            newpipe = pipePool.Pop();
            //newpipe.transform.position = pipes.transform.position;
            newpipe.SetActive(true);
        } else {
            newpipe = GameObject.Instantiate(pipe, pipes);
            generatePositon = newpipe.transform.position;
        }
        //newpipe = GameObject.Instantiate(pipe, pipes);
        newpipe.GetComponent<PipeScript>().RandomHeight();
        pipeList.Add(newpipe);
    }

    public void Update() {
        for(int i = pipeList.Count - 1; i >= 0; i--) {
            if (pipeList[i].transform.position.x < -6) {
                pipePool.Push(pipeList[i]);
                pipeList[i].SetActive(false);
                pipeList[i].transform.position = generatePositon;
                //Destroy(pipeList[i]);
                pipeList.RemoveAt(i);
            }
        }

    }
}
