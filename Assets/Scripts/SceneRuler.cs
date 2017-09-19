using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRuler : MonoBehaviour { 
    public enum Name {Title,Main,Result };//シーン名一覧
    public Name NextSceneName;//遷移先シーン名

    private static string[] SceneName = new string[] { "Title","Main","Result"};//string型シーン名

    public void SceneChange(){
        int Index = (int)NextSceneName;//キャスト変換で、アクセスすべき配列のインデックスを求める
        SceneManager.LoadScene(SceneName[Index]);//シーンをロードする
    }

}
