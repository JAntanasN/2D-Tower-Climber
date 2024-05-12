using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Ladders")]
    public Transform leftLadder;
    public Transform rightLadder;

    [Header("Bows")]
    public Transform RightSideBow;
    public Transform LeftSideBow;

    [Header("PlayerSettings")]
    public float ladderSwitchDuration = 1.0f;
    public float climbSpeed = 5f;
    public float maxDownwardMovement = 1.0f;

    [Header("Animations")]
    private Animator animator;


    [Header("Ladders settings")]
    private bool isClimbing = false; 
    private bool isSwitchingLadder = false; 
    private Vector3 targetLadderPosition;

    [Header("Camera")]
    public Transform camera;
    

    private float verticalMovement = 0f;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

            animator.SetBool("Climb", true);

            Vector3 movement = Vector3.up * climbSpeed * Time.deltaTime;

            transform.Translate(movement);
            leftLadder.Translate(movement);
            rightLadder.Translate(movement);
            camera.transform.Translate(movement);
            RightSideBow.Translate(movement);
            LeftSideBow.Translate(movement);




            verticalMovement = 0f;
        }
        else if (Input.GetKey(KeyCode.S) && verticalMovement > -maxDownwardMovement)
        {

            animator.SetBool("Climb", true);

            Vector3 movement = Vector3.down * climbSpeed * Time.deltaTime;

            transform.Translate(movement);
            leftLadder.Translate(movement);
            rightLadder.Translate(movement);
            camera.transform.Translate(movement);
            RightSideBow.Translate(movement);
            LeftSideBow.Translate(movement);


            verticalMovement -= climbSpeed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("Climb", false);
        }
        
        

        if (!isSwitchingLadder && Input.GetKeyDown(KeyCode.D) && transform.position.x < rightLadder.position.x)
        {
            SwitchLadder(rightLadder.position);
        }
        else if (!isSwitchingLadder && Input.GetKeyDown(KeyCode.A) && transform.position.x > leftLadder.position.x)
        {
            SwitchLadder(leftLadder.position);
        }

    }

    void SwitchLadder(Vector3 targetPosition)
    {
        isSwitchingLadder = true;
        targetLadderPosition = targetPosition;
        StartCoroutine(MoveToLadder());
    }

    IEnumerator MoveToLadder()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        while (elapsedTime < ladderSwitchDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetLadderPosition, elapsedTime / ladderSwitchDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetLadderPosition;
        isSwitchingLadder = false;
    }
}


