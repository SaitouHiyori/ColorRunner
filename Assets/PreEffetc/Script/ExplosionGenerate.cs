using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGenerate : MonoBehaviour
{

    //public GameObject explosionParticle;//爆発パーティクル

    //public Transform[] explosionPoint;//爆発地点

    public GameObject ExplosionPre;
    public Vector3 ExplosionPos;
    public Vector3 ExplosionRoll;

    public void IsException()
    {
        Instantiate(ExplosionPre, transform.position + ExplosionPos, Quaternion.Euler(ExplosionRoll));
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    foreach (Transform explosionPos in explosionPoint)
        //    {
        //        GameObject expl = Instantiate(explosionParticle,               // パーティクルオブジェクトの生成
        //            explosionPos.position, transform.rotation) as GameObject;

        //        Destroy(expl, 5f);                                             // ５秒後に消す
        //    }
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            IsException();
            //foreach (Transform explosionPos in explosionPoint)
            //{
            //    GameObject expl = Instantiate(explosionParticle,               // パーティクルオブジェクトの生成
            //        explosionPos.position, transform.rotation) as GameObject;

            //    Destroy(expl, 5f);                                             // ５秒後に消す
            //}
        }
    }
}
