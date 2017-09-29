using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabeler : MonoBehaviour {
    public enum ObjectJanle { ScoreLabel,RunMater}
    public ObjectJanle Janle;

    private Text Text;
    private Player Player;

    private void Awake(){
        Text = GetComponent<Text>();
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update(){
        switch (Janle){
            case ObjectJanle.ScoreLabel:
                Text.text = string.Format("SCORE:{0:000}", GameManager.Score);
                break;
            case ObjectJanle.RunMater:
                Text.text = string.Format("{0:00,0}KM", Player.RunScore);
                break;
            default:
                Text.text = "ERROR";
                break;
        }

    }

}