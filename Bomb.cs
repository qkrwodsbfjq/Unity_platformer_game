//==========================================
// writer : 노현석.
// file : Bomb.cs.
// content : 스테이지에서 폭탄 오브젝트에 대한 기본 스크립트.
// discript : 플레이어와 충돌시 플레이어 n만큼의 데미지 + 오브젝트 제거 + 그자리에 이런저런 이펙트.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float BombDamage = 10f;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] ParticleSystem explosionParticleEffect;
    [SerializeField] float secondsToDestroyVFX;

    Collider2D myCollider;
    Rigidbody2D myRigidbody;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float enemyDirection = collision.gameObject.transform.position.x - transform.position.x;
            playerController.RecieveDamage(BombDamage, enemyDirection);
            var explosionVFX_ = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            var particleVFX_ = Instantiate(explosionParticleEffect, transform.position, Quaternion.identity);
            Destroy(particleVFX_, secondsToDestroyVFX);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyVFXObjects(GameObject gameObjectToDestroy, float secondsLater)
    {
        yield return new WaitForSeconds(secondsLater);
        Destroy(gameObjectToDestroy);
    }
}
