using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sprits
{
    public class Jugador: MonoBehaviour
    {
        public float fuerzaSalto;

        private Rigidbody2D rigidbody2D;
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("estaSaltando", true);
                rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Suelo")
            {
                animator.SetBool("estaSaltando", false);
            }

            
        }
    }
}
