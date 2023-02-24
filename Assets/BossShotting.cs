using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotting : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    PlayerSamurai playerSamurai;
    bool isShooted = false;
    [SerializeField] float FireSpeed = 5f;
    Vector2 target;
    
    private void Awake() {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerSamurai = FindAnyObjectByType<PlayerSamurai>();
    }
    void Start()
    {
        
        target = new Vector2(playerSamurai.transform.position.x, playerSamurai.transform.position.y);
        Debug.Log("nguoi choi " +playerSamurai.transform.position);
        Debug.Log(transform.position);
        isShooted = true;
    }

    private void Update() {
        Vector2 newPos = Vector2.MoveTowards(myRigidBody.position,target,0.2f);
        Debug.Log(newPos);
        myRigidBody.MovePosition(newPos);
        isShooted = false;
        if(myRigidBody.position == newPos){
            Destroy(gameObject);
        }
    }


}
