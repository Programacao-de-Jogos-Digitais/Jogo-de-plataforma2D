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

    public bool isJumping;
    public bool doubleJumping;

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
            //Se não estiver pulando, esta no chão
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce),  ForceMode2D.Impulse);
                doubleJumping = true;
                print("Jump");
                // isJumping = true;
            }
            
            //Se estiver pulando, pronto para o segundo pulo
            if(doubleJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce * 2.2f),  ForceMode2D.Impulse);
                doubleJumping = false;
                print("Double Jump");
            }
            
        }
    }

    //É chamado quando o personagem tocar em alguma coisa
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            //quando o personagem esta tocando o chão
            isJumping = false;
            print("tocou no chão");
        }
    }

    //É chamado quando o personagem para de tocar em algo
     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            //quando o personagem esta pulando
            isJumping = true;
            doubleJumping = true;
            print("deixou de tocar o chão!");
        }
    }
}
