using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
 [SerializeField] private float attackCooldown;
 [SerializeField] private Transform firePoint;
 [SerializeField] private GameObject[] fireballs;

 private Animator anim;
 private PlayerMovement playerMovement;
 private float cooldownTimer = Mathf.Infinity;

private void Awake(){
    anim = GetComponent<Animator>();
    playerMovement = GetComponent<PlayerMovement>();
}

private void Update(){
    if(Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
    Attack();

    if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Space) && cooldownTimer > attackCooldown && playerMovement.canJumpAttack())
    JumpAtk();

    if(Input.GetMouseButtonDown(1) && cooldownTimer > attackCooldown && playerMovement.fireAttack())
    Fire();

    cooldownTimer += Time.deltaTime;
}

private void Attack(){
    anim.SetTrigger("SwordAttack");
    cooldownTimer = 0;
}
 private void JumpAtk(){
    anim.SetTrigger("JumpAttack");
    cooldownTimer = 0;
 }

 private void Fire(){
    anim.SetTrigger("FireSword");
    cooldownTimer = 0;
    fireballs[0].transform.position = firePoint.position;
    fireballs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
 }


}
