using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{

    public GameObject explosionParticle;        // 爆発パーティクル

    public Transform[] explosionPoints;         // 爆発地点

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))   // プレイヤーが踏むと動作する
        {
            foreach (Transform explosionPos in explosionPoints)
            {
                GameObject expl = Instantiate(explosionParticle,               // パーティクルオブジェクトの生成
                    explosionPos.position, transform.rotation) as GameObject;

                Destroy(expl, 5f);                                             // ５秒後に消す
            }
        }
    }
}