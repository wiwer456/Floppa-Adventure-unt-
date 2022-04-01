using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveBind : MonoBehaviour
{
    public GameObject item;
    public Rigidbody pitem;

    Rigidbody sus; 
    Transform trnsf;
    bool grounded = false;

    static int meets = 0;
    static int ingrs = 0; 

    float vertical;
    float horizontal;
    float jumpForce = 10f;

    void Start()
    {
        sus = GetComponent<Rigidbody>();
        trnsf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        sus.AddRelativeForce(0,0, vertical * 50f);
        trnsf.Rotate(0, horizontal*5f, 0);

        if(Input.GetKeyDown("space") && grounded == true){
            sus.drag = 2;
            sus.angularDrag = 2;
            sus.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        if(Input.GetKeyDown("g")){
            item.transform.SetParent(null);
        }
        if(Input.GetKeyDown("h")){
            trnsf.rotation = Quaternion.identity;
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            sus.AddRelativeForce(0,0, vertical * 200f);
        }
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "floor"){
            grounded = true;
        }
        if(col.gameObject.tag == "testo"){
            ingrs += 1;
            Destroy(col.gameObject);
            print("+ тесто");
        }
        if(col.gameObject.tag == "item"){
            Destroy(col.gameObject);
            meets += 1;
            print(meets);
            print("+ мясо");
        }
        if(col.gameObject.tag == "go"){
            if(meets == 3){
                Destroy(col.gameObject);
                print("ты сделал фарш");
                ingrs += 1;
            }
        }
        if(col.gameObject.tag == "do"){
                if(ingrs == 2){
                    print("ты сделал пельмени");
                    Destroy(col.gameObject);
                }
            }
    }
    void OnCollisionExit(Collision col){
            if(col.gameObject.tag == "floor"){
            grounded = false;
        }
    }
    
}
