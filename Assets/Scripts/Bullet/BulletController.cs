using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header ("Parameters")]
    [SerializeField] float speed;
    [SerializeField] float damage;
    Vector3 ShotDirection;


    public void SetDirection(Vector3 direction){
        ShotDirection = direction;
    }    


    void Update(){
        Move();
        if(ScreenOffLimit()) DestroyBullet();
    }
    void Move(){
        transform.position += ShotDirection * Time.deltaTime * speed;
    }


    Vector2 GetScreenLimit(){
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    bool ScreenOffLimit(){
        if(transform.position.x > GetScreenLimit().x) return true;
        else return false;
    }

    void DestroyBullet(){
        Destroy(this.gameObject);
    }

}
