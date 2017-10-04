using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleColor : MonoBehaviour {
    public Image road;
	void Start () {
        StartCoroutine("_color");
	}
	
	// Update is called once per frame
	IEnumerator _color () {
        while (true)
        {
            for (int R = 0; R < 20; R++)
            {
                road.color += new Color(0, 0.05f, 0);
                yield return new WaitForSeconds(0.1f);
            }
            for (int Y = 0; Y < 20; Y++)
            {
                road.color += new Color(-0.05f, 0, 0);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);


            for (int G = 0; G < 20; G++)
            {
                road.color += new Color(0, 0, 0.05f);
                yield return new WaitForSeconds(0.1f);
            }
            for (int C = 0; C < 20; C++)
            {
                road.color += new Color(0, -0.05f, 0);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);


            for (int B = 0; B < 20; B++)
            {
                road.color += new Color(0.05f, 0, 0);
                yield return new WaitForSeconds(0.1f);
            }
            for (int P = 0; P < 20; P++)
            {
                road.color += new Color(0, 0, -0.05f);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);

        }
    }
}
