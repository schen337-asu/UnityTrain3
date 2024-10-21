using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 10;
    public bool isOnGround = true;
    private bool gameOver = false;

    // normal space gravity 1 = 9.81 m/s^2
    public float gravityModifier = 1.4f;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // playerRb.AddForce(Vector3.up * 1000);
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            // jump trigger in animator submenu in jumping as transition from (default state -"run" to "jump")
            // "jump_trig" is the transition call with a animation script that includes duration length.
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    public bool getGameState() {
        return gameOver;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } 
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
