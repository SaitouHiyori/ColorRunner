using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScore : MonoBehaviour {
    private const int _runscore=1;
    private const float time=1;
    private bool _Running = false;
<<<<<<< HEAD
    void Update()
    {
        if (GameManager.Flag==false&&_Running)
        {
=======
    void Update(){
        if (!GameManager.Flag&&_Running){
>>>>>>> 1b05baaaa0703804d506aafd92805b3e9c6f9920
            StopCoroutine("RunTimeScore");
            _Running = false;
        }
    }

<<<<<<< HEAD
    void Start()
    {
=======
    public void CoroutineStart(){
>>>>>>> 1b05baaaa0703804d506aafd92805b3e9c6f9920
        StartCoroutine("RunTimeScore");
        _Running = true;
    }

<<<<<<< HEAD
    private IEnumerator RunTimeScore()
    {
        while (true)
        {
            GameManager.Score=_runscore;
=======
    private IEnumerator RunTimeScore(){
        while (true){
            GameManager.Score = _runscore;
>>>>>>> 1b05baaaa0703804d506aafd92805b3e9c6f9920
            yield return new WaitForSeconds(time);
        }
    }
}
