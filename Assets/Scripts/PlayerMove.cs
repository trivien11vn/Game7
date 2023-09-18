using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rollSpeed = 2f;
    private float rollTime;
    public float SetRollTime;
    bool isRoll = false;

    private Rigidbody2D rb;
    public Vector3 moveInput;
    public Animator animator;
    public SpriteRenderer characterSprite;
    private void Start(){
    }
    private void Update(){
        moveInput.x = Input.GetAxis("Horizontal"); //
        moveInput.y = Input.GetAxis("Vertical");    
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        animator.SetFloat("Speed",moveInput.sqrMagnitude);
        if(moveInput.x != 0){
            if(moveInput.x > 0){
                characterSprite.transform.localScale = new Vector3(1f,1f,0f);
            }
            else{
                characterSprite.transform.localScale = new Vector3(-1f,1f,0f);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && rollTime <= 0){
            animator.SetBool("isRoll", true);
            moveSpeed += rollSpeed;
            rollTime = SetRollTime;
            isRoll = true;
        }
        if(rollTime <= 0 && isRoll){
            moveSpeed -= rollSpeed;
            isRoll = false;
            animator.SetBool("isRoll", false);
        }
        else{
            rollTime -= Time.deltaTime;
        }
    }
}
