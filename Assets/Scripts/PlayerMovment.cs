using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float airMultipplyer = 0.5f;
    public Transform groundObject;
    public LayerMask layerMask;
    private Rigidbody2D rig;
    public Animator animator;

    AudioSource audiosource; 



    private float move;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");

        //rig.AddForce(transform.right * move * speed * Time.deltaTime, ForceMode2D.Force);
        transform.position +=  new Vector3(move * speed * Time.deltaTime * (isgrounded() ? 1 : airMultipplyer), 0, 0);
        //kanske translate

        animator.SetFloat("Speed", Mathf.Abs(move));

        if (move * speed * Time.deltaTime > 0)
        {
            Debug.Log("hehehe");
            if (!audiosource.isPlaying)
            {
                audiosource.Play(); 
            }
        }
        else
        {
            audiosource.Stop(); 
        }


        if (isgrounded() && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rig.velocity.y! < 0.1)
        {
            Jump();
            animator.SetBool("IsJumping", true);
        }

        if (isgrounded() && rig.velocity.y <= 0 ) OnLanding();


    }

    public void OnLanding ()
    {
      animator.SetBool("IsJumping", false);
    }
    //Varf�r �r isgrounded med ett litet i... f�r jag orkar inte �ndra nu
    //Men jag orkar skriva en kommentar om att det 
    private bool isgrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundObject.position, 0.45f, Vector2.down, 0.1f, layerMask);
        Color raycolor;
        if (hit.collider != null)
        {
            raycolor = Color.green;
        }
        else
        {
            raycolor = Color.red;
        }
        Debug.DrawRay(groundObject.position, Vector2.down * 0.1f, raycolor);
        return hit.collider != null;
    }
    public void Jump()
    {
        rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
}