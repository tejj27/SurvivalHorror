using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimation : MonoBehaviour
{

    public int LightMode;
    public GameObject FlameLight;


    void Update()
    {
        if(LightMode == 0)
        {
            StartCoroutine(AnimateLight ());
        }
    }

    IEnumerator AnimateLight ()
    {
        LightMode = Random.Range(1, 4);
        if(LightMode == 1)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim_1");
        }
         if(LightMode == 2)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim_2");
        }
         if(LightMode == 3)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim_3");
        }
        yield return new WaitForSeconds(0.99f);
        LightMode = 0;
    }
}
