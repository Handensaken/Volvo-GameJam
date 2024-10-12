using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform groundObject;
    public LayerMask layerMask;
    private Rigidbody2D rig;

    private float move;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.Log(isgrounded());
        move = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(move * speed, rig.velocity.y);

        if (isgrounded() && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && rig.velocity.y! < 0.1)
        {
            Jump();
        }
    }
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