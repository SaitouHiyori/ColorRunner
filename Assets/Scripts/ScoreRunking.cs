using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreRunking : MonoBehaviour {
    
    private List<int> _Score = new List<int>() {0,0,0};
    public Text scorebord;//表示用Text

    private string[] _ScoreRankKey= { "score1","score2","score3"};
    private int[] _SaveI= {0,0,0};
    private Player player;
    void Start(){
        player = FindObjectOfType<Player>();
        for (int i = 0; i < 3; i++){
            _SaveI[i] = PlayerPrefs.GetInt(_ScoreRankKey[i], 0); }
        _Score = new List<int>(_SaveI);
        if (GameObject.Find("scorebord"))
        {
            scorebord.text = "<color=#ff0000>" + "1　" + _Score[0].ToString() + "</color>"
                + "<color=#0066ff>" + "\n2　" + _Score[1].ToString() + "</color>"
                + "<color=#11ff00>" + "\n3　" + _Score[2].ToString() + "</color>";
        }
    }

    
    public void ScoreAdd(){
        _Score.Add(GameManager.Score+player.RunScore);
        _Score.Sort();
        _Score.Reverse();
        _Score.RemoveAt(3);
        _SaveI = _Score.ToArray();
        for (int i = 0; i < 3; i++){
            PlayerPrefs.SetInt(_ScoreRankKey[i], _SaveI[i]); }
        PlayerPrefs.Save();
    }

    public void DeleteData(){
        PlayerPrefs.DeleteAll();
        _Score = new List<int>() { 0, 0, 0};
        _SaveI = new int[]{ 0,0,0};

    }
}
