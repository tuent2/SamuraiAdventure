using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int heath = 100;
    [SerializeField] int score = 50;
    [SerializeField] string hitEffect;
    
    Animator myAnimator;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Damage damage = other.GetComponent<Damage>();
        if (damage != null){
            TakeDame(damage.GetDamage());
            playHitEffect();
            // ShakeCamera();
            // audioPlayer.PlayerGetDamageAudio();
            // heath -=damage.GetDamage();
            // damage.Hit();
        }
    }

    void AttackEnemy (){

    }

    void playHitEffect(){
        if(hitEffect !=null){
            myAnimator.SetTrigger(hitEffect);
        }
    }

    void TakeDame(int damageValue)
    {   
        heath -= damageValue;
        if(heath <= 0){
            if(!isPlayer){
                scoreKeeper.setCurrentScore(score);
            }
            // else
            // {
            //     levelManager.LoadGameOver();
            // }
            Debug.Log("Destroy");
            Destroy(gameObject);

        }
    }

    public int getHeath(){
        return heath;
    }
}
