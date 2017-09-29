using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGenerate : MonoBehaviour {

    public GameObject explosionParticle;//爆発パーティクル

    public Transform[] explosionPoint;//爆発地点
                                      // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Transform explosionPos in explosionPoint)
            {
                GameObject expl = Instantiate(explosionParticle,               // パーティクルオブジェクトの生成
                    explosionPos.position, transform.rotation) as GameObject;

                Destroy(expl, 5f);                                             // ５秒後に消す
            }
        }
    }
}
