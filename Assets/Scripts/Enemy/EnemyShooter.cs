using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header ("Prefabs")]
    [SerializeField] GameObject bullet;


    // Update is called once per frame
    void Start()
    {
        StartCoroutine("shot");
    }

    IEnumerator shot(){
        

        GameObject newShot;
        newShot = Instantiate(bullet, transform.position, Quaternion.identity);
        newShot.transform.parent = GameObject.Find("__Dynamic").transform; 
        
        newShot.GetComponent<EnemyShoot>().SetDirection(Vector3.left);
        yield return new WaitForSeconds(2);
        StartCoroutine("shot");
        
    }
}
