using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasolineMater : MonoBehaviour {

    public Vector3 FullGasolineRotate;
    public Vector3 EmptyGasolineRotate;
    public Vector3 NowGasolineRotate;//現在のガソリン量から求められる傾き
    public Vector3 IntarfaceGasolineRotate;//現在表示しているガソリン量

    private RectTransform RT;

    private Player Player;

    private void Awake(){
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        RT = GetComponent<RectTransform>();
    }

    private void Update(){
        Vector3 NewGasolineRotate = new Vector3();
        float MoveN = Player.Gasoline / Player.MaxGasoline;

        NewGasolineRotate = EmptyGasolineRotate * (1 - MoveN) + FullGasolineRotate * MoveN;
        RT.rotation = Quaternion.Euler(NewGasolineRotate);

    }

}
