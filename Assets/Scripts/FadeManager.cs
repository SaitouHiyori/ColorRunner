using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    public enum FadeFlag { FadeIn,FadeOut}
    private FadeFlag SwichFlag;

    public float FadeTime;//フェードにかかる時間
    private float AddAlpha;

    private Image Image;

    private IEnumerator FadeOut(){
        while (true){
            Color NewColor = Image.color;
            NewColor.a -= AddAlpha;
            Image.color = NewColor;
            if(Image.color.a <= 0){//透明になったら終了
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Destroy(transform.parent.gameObject);//親Canvas破棄
    }//画面が明るくなる

    private IEnumerator FadeIn(){
        while (true){
            Color NewColor = Image.color;
            NewColor.a += AddAlpha;
            Image.color = NewColor;
            if (Image.color.a >= 1){//暗くなったら終了
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }

    private IEnumerator Fader(){
        switch (SwichFlag){
            case FadeFlag.FadeIn:
                yield return StartCoroutine(FadeIn());
                break;
            case FadeFlag.FadeOut:
                yield return StartCoroutine(FadeOut());
                break;
            default:
                break;
        }

    }

    public void FadeStart(FadeFlag Flag){
        SwichFlag = Flag;
        StartCoroutine(Fader());
    }

    private void Awake(){
        Image = GetComponent<Image>();
    }

    private void Start(){
        float FadeCount = FadeTime * 60;//秒数をフレーム数換算
        AddAlpha = 1 / FadeCount;//１回あたりの変化量を求める
    }
}
