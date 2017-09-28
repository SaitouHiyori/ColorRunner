using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ItemGetSound : MonoBehaviour {

    public float SoundPlayTime;//再生時間

    private AudioSource AudioSource;

    private IEnumerator DestroyTimer(){
        yield return new WaitForSeconds(SoundPlayTime);
        Destroy(this.gameObject);
    }

    public void SEPlay(){
        AudioSource = GetComponent<AudioSource>();
        AudioSource.Play();
        StartCoroutine(DestroyTimer());
    }

}
