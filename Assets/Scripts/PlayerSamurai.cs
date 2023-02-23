using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerSamurai : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D mySword;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float disRun = 6f;

    void Awake() {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();
        mySword = gameObject.GetComponent<CapsuleCollider2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        OnWalking();
        FlipSprite();
    }

    void OnMove(InputValue inputValue){
        moveInput= inputValue.Get<Vector2>();
    }

    void OnJump(InputValue inputValue){

    }

    void OnSkillQ(InputValue inputValue){
        myAnimator.SetTrigger("UsingQ");
    }

    void OnSkillE(InputValue inputValue){
        myAnimator.SetTrigger("UsingE");
    }

    void OnSkillF(InputValue inputValue){
        myAnimator.SetTrigger("UsingF");
    }


    void OnWalking(){
        
        bool playerIsWalking = Mathf.Abs(myRigidbody.velocity.x) >Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerIsWalking);
        if(Input.GetKey(KeyCode.LeftShift) && playerIsWalking) {
            Vector2 playerVeloctity = new Vector2 (Mathf.Clamp(moveSpeed+disRun , moveSpeed,float.MaxValue)* moveInput.x,Mathf.Clamp(moveSpeed+disRun , moveSpeed,float.MaxValue)* moveInput.y);
            myRigidbody.velocity = playerVeloctity;
            
            myAnimator.SetBool("isRunning", true);
        }
        else {
            Vector2 playerVeloctity = new Vector2 (moveSpeed * moveInput.x,moveSpeed * moveInput.y);
            // Vector2 playerVeloctity = new Vector2 (moveSpeed * moveInput.x,myRigidbody.velocity.y);
            myRigidbody.velocity = playerVeloctity;

            myAnimator.SetBool("isRunning", false);
        }
    }

    void AttackEnemy(){
        if (!mySword.IsTouchingLayers(LayerMask.GetMask("Boss")))
        {
            
        }
    }

    void FlipSprite(){
        bool playerIsMoving = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(playerIsMoving){
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x),1f);
        }
    }
}
