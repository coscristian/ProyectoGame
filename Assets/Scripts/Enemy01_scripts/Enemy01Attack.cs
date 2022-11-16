using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Attack : MonoBehaviour
{
    [SerializeField] private float range = 3f;
    [SerializeField] private float timeBetweenAttacks = 1f;
    private Animator anim;
    private GameObject player;
    private bool playerInRange;
    private BoxCollider weaponCollider;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameManager.instance.Player;
        weaponCollider = GetComponentInChildren<BoxCollider>();
        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < range) {
            playerInRange = true;
        }else{
            playerInRange = false;
        }
        print("Player in range: " + playerInRange);
    }

    IEnumerator attack() {
        if(playerInRange && !GameManager.instance.GameOver) {
            anim.Play("enemy_default_attact");
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
        yield return null;
        StartCoroutine(attack());
    }



}
