using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variável de velocidade do personagem
    public float Speed;
    
    //Variável Força do pulo
    public float JumpForce;

    //Variável rigidbody
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        //Vai receber o componente rigidbody anexado ao script
        //O script busca algum componente do tipo rigidbody 
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Chama o método
        Move();
        Jump();
    }

    //Método controla a velocidade de movimento
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(0f, JumpForce),  ForceMode2D.Impulse);
        }
    }
}
