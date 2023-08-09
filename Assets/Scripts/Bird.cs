using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    bool isClick=false;
    public Transform RightPos;
    public float MaxDis=3;
    SpringJoint2D sp;
    Rigidbody2D rg;
    private void Awake() {
        sp=GetComponent<SpringJoint2D>();
        rg=GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown() {
        isClick=true;
        rg.isKinematic=true;
        Debug.Log(1);
    }
    private void OnMouseUp() {
        isClick=false;
        rg.isKinematic=false;
        Invoke("Fly",0.1f);
        Debug.Log(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isClick){
            transform.position=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position+=new Vector3(0,0,-Camera.main.transform.position.z);
        if (Vector3.Distance(transform.position,RightPos.position)>MaxDis)
        {
            Vector3 pos=(transform.position-RightPos.position).normalized;
            pos*=MaxDis;
            transform.position=pos+RightPos.position;
        }
        }
    }
    void Fly(){
        sp.enabled=false;
    }

}
