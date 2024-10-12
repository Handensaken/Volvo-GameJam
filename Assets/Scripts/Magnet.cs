using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magnet : MonoBehaviour
{
    public float range = 5f;
    public float pushForce = 5f;
    public float pullForce = 5f;
    public LayerMask layerMask;
    public Charge charge;
    public bool IsActive = true;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, layerMask);
        if (colliders.Length > 0)
        {
            foreach (var collider in colliders)
            {
                if (collider.gameObject != this.gameObject)
                {
                    if (charge != Charge.Non && IsActive && collider.gameObject.GetComponent<Magnet>().IsActive)
                    {
                        if (charge == collider.gameObject.GetComponent<Magnet>().charge)
                        {
                            Push(collider.gameObject);
                        }
                        else
                        {
                            Pull(collider.gameObject);
                        }
                    }
                }
            }
        }
    }
    public void OnChargeChange(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            IsActive = !IsActive;
        }
    }
    private void Pull(GameObject player)
    {
        rb.AddForce(-(transform.position - player.transform.position).normalized * pullForce * 0.1f, ForceMode2D.Impulse);
    }
    private void Push(GameObject player)
    {
        float temp = Vector2.Distance(player.transform.position, transform.position);
        temp = temp / range;
        Debug.Log(temp);
        rb.AddForce((transform.position - player.transform.position).normalized * pushForce * 0.1f * temp, ForceMode2D.Impulse);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range/2);
    }
}
public enum Charge
{
    Non,
    Positive,
    Negative
}
