﻿using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO.MemoryMappedFiles;
using System.Xml.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed; 
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject table;
    [SerializeField] GameObject untable;
    private bool tab = false;
    public bool pl = false;
    public float rad = 7f;
    private Animator anim;
    [SerializeField] bool right = true, left, up, down;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (tab == false)
                {
                    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rad);
                    foreach (Collider2D hitCollider in hitColliders)
                    {
                        hitCollider.SendMessage("Take", SendMessageOptions.DontRequireReceiver);
                        table.SetActive(true);
                        tab = true;
                        pl = !pl;
                        anim.SetBool("hand", true);
                    }

                }
                else
                {
                    tab = false;
                    table.SetActive(false);
                    untable.GetComponent<untable>().un = !untable.GetComponent<untable>().un;
                    pl = !pl;
                    anim.SetBool("hand", false);
                }
            }
            Vector2 direction = transform.position;
            if (Input.GetKey(KeyCode.W))
            {
                direction.y += speed * Time.deltaTime;
                anim.SetBool("up", true);
                anim.SetBool("left", false);
                anim.SetBool("down", false);
                anim.SetBool("right", false);
                if (tab)
                {
                    anim.SetBool("hup", true);
                }
                    }
            if (Input.GetKey(KeyCode.S))
            {
                direction.y -= speed * Time.deltaTime;
                anim.SetBool("up", false);
                anim.SetBool("left", false);
                anim.SetBool("down", true);
                anim.SetBool("right", false);
                if (tab)
                {
                    anim.SetBool("hdown", true);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction.x += speed * Time.deltaTime;
                anim.SetBool("up", false);
                anim.SetBool("left", false);
                anim.SetBool("down", false);
                anim.SetBool("right", true);
                if (tab)
                {
                    anim.SetBool("hup", true);
                }

            }
            if (Input.GetKey(KeyCode.A))
            {
                direction.x -= speed * Time.deltaTime;
                anim.SetBool("up", false);
                anim.SetBool("left", true);
                anim.SetBool("down", false);
                anim.SetBool("right", false);
                if (tab)
                {
                    anim.SetBool("hdown", true);
                }
            }
            transform.position = direction;
            if (Input.GetKeyUp(KeyCode.D)){
                anim.SetBool("right", false);
                if (tab)
                {
                    anim.SetBool("hup", false);
                }
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (tab)
                {
                    anim.SetBool("hup", false);
                }
                anim.SetBool("hdown", false);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                if (tab)
                {
                    anim.SetBool("hup", false);
                }
                anim.SetBool("up", false);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                if (tab)
                {
                    anim.SetBool("hdown", false);
                }
                anim.SetBool("left", false);
            }
        }
    }
}
