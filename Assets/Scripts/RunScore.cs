using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScore : MonoBehaviour {
    private const int _runscore=1;
    private const float time=1;
    private bool _Running = false;
    void Update(){
        if (!GameManager.Flag&&_Running){
            StopCoroutine("RunTimeScore");
            _Running = false;
        }
    }

    public void CoroutineStart(){
        StartCoroutine("RunTimeScore");
        _Running = true;
    }

    private IEnumerator RunTimeScore(){
        while (true){
            GameManager.Score = _runscore;
            yield return new WaitForSeconds(time);
        }
    }
}
