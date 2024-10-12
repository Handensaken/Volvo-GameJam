using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    public Transform groundObject;
    public LayerMask layerMask;
    public float speed = 5f;
    private Vector2 movementInput;
    public Rigidbody2D rB;

    //[SerializeField]
    //private SceneBehaviour sceneManager;
    [SerializeField]
    private float JumpForce;

    [SerializeField]
    private Animator anim;

    private bool walkAnimPlaying;

    // Start is called before the first frame update
    void Start()
    {
        walkAnimPlaying = false;
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = 0; j < colliders.Length; j++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[j]);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
            anim.Play("Walk");

        //    anim.SetBool("fucker", true);
       /* if (movementInput.x > 0)
        {
            Debug.Log("cuck");
            anim.Play("Walk");
            //Walk forward
        }
        else if (movementInput.x < 0)
        {
            Debug.Log("buck");
            anim.Play("WalkBack");
            //walk backward
        }
        if (!walkAnimPlaying)
        {
            Debug.Log("ruck");
            anim.Play("Idle");
        }*/

        transform.Translate(new Vector2(movementInput.x, movementInput.y) * speed * Time.deltaTime);
        
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
        walkAnimPlaying = true;
    }

    public void OnJump()
    {
        if (isgrounded())
        {
            rB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    private bool isgrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            groundObject.position,
            0.45f,
            Vector2.down,
            0.1f,
            layerMask
        );
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

    /*  private void OnCollisionEnter2D(Collision2D col)
      {
          Debug.Log(col.gameObject.name);
          if (col.gameObject.CompareTag("Hazard"))
          {
              Debug.Log("huhrensohn");
              sceneManager.LoadSceneDelayed("Max", 3);
              Destroy(gameObject);
          }
      }
  */
}
