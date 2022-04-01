using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDestroyer : MonoBehaviour
{
    static int Idestroyed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Idestroyed == 4){
            print("крут");
        }
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "dellay"){
            Destroy(col.gameObject);
            Idestroyed += 1;
            print("ddddddddddd");
        }
    }
}
