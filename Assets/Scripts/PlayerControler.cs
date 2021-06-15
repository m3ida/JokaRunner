using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControler : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;

    private float moveSpeedStore;

    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidBody;

    public bool Grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;


    //private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource DeathSound;


    private GameObject theCat;
    private GameObject theDog;

    private int choosenChar;

    //private bool Dog;


    // Start is called before the first frame update
    void Start()
    {
        theDog = GameObject.Find("Dog");
        theCat = GameObject.Find("Cat");

        jumpSound.volume = PlayerPrefs.GetFloat("SFXVolume");
        DeathSound.volume = PlayerPrefs.GetFloat("SFXVolume");


        if (PlayerPrefs.HasKey("ChoosenChar"))
        {
            choosenChar = PlayerPrefs.GetInt("ChoosenChar");
        } 
        else
        {
            choosenChar = 0;
        }

        myRigidBody = GetComponent<Rigidbody2D>();



        //myAnimator.SetLayerWeight(myAnimator.GetLayerIndex("dogLayer"), 1f);

        //myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;

        speedMilestoneCountStore = speedMilestoneCount;

        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;

        if (choosenChar == 0)
        {
            theCat.SetActive(false);
            theDog.SetActive(true);
        }
        else
        {
            theDog.SetActive(false);
            theCat.SetActive(true);
        }

        /*if (PlayerPrefs.HasKey("Dog"))
        {
            Dog = PlayerPrefs.GetInt("Dog");
        }

        myAnimator.runtimeAnimatorController = Resources.Load("Assets/Prefabs/Dog.controller") as RuntimeAnimatorController;

        if (myAnimator.gameObject.activeSelf)
        {
            myAnimator.Play("DogIdle");
        }*/

        //myAnimator.SetBool("Dog", Dog);
    }

    // Update is called once per frame
    void Update()
    {
        //Grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        Grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed *= speedMultiplier;
        }

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpSound.Play();
            }
            if(!Grounded && canDoubleJump)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
                jumpSound.Play();
            }
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if(jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)|| Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (Grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded", Grounded);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            DeathSound.Play();
            theGameManager.restartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }
}
