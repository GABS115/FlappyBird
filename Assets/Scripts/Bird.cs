using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rig;
    public float jumpForce;
    public Animator animator; 

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rig.bodyType = RigidbodyType2D.Static;
    }




    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.status)
        {
            case GameStatus.Start:
                StartUpdate();
                break;
            case GameStatus.Play:
                PlayUpdate();
                break;
            case GameStatus.GameOver:
                GameOverUpdate();
                break;
        }
    }

    public void StartGame()
    {
        rig.bodyType = RigidbodyType2D.Dynamic;
        Jump();
        animator.SetBool("isAlive", true);
    }
    void StartUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //GameManager.instance.status = GameStatus.Play;
            GameManager.instance.StartGame();
            

        }

    }

    void PlayUpdate()

    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        rig.velocity = Vector3.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        GameOver();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 6:
                GameOver();
                break;

            case 7:
                GameManager.instance.AddScore();
                break;

            default:
                break;
        }
    }

    private void GameOver()
    {
        if(GameManager.instance.status == GameStatus.GameOver)
        {
            return;
        }
        GameManager.instance.GameOver();
        animator.SetBool("isAlive", false);
        Jump();
    }
    void GameOverUpdate()
    {

    }

    public void Restart()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rig.bodyType = RigidbodyType2D.Static;
        animator.SetBool("isAlive", true);

    }

}






