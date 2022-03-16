using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage =2f;

    public float Radius = 1f;

    public LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, Radius, layerMask);

        if(hits.Length > 0)
        {
            // that means we can hit or touch the game object'

            print("We touched : " + hits[0].gameObject.tag);
            gameObject.SetActive(false);

        } 
    }
}
