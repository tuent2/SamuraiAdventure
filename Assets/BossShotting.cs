using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotting : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    PlayerSamurai playerSamurai;
    Animator myAnimator;
    [SerializeField] float FireSpeed = 5f;
    Vector2 target;
    
    private void Awake() {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerSamurai = FindAnyObjectByType<PlayerSamurai>();
        myAnimator = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        target = new Vector2(playerSamurai.transform.position.x, playerSamurai.transform.position.y);
    }

    private void Update() {
        Vector2 newPos = Vector2.MoveTowards(myRigidBody.position,target,0.2f);
        myRigidBody.MovePosition(newPos);
        if(myRigidBody.position == newPos){
            myAnimator.SetTrigger(name: "isFinish");
            StartCoroutine( FireGone());
        }
    }

    IEnumerator FireGone(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
