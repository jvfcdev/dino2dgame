using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rig;

    public float speed;
    public float jumpForce;

    public Transform camera;
    public Transform fundo;

    private Animator animator;

    private bool pulando = false;

    private AudioSource somPulo;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        camera.position = new Vector3(rig.transform.position.x + 3,0,-10);
        animator = GetComponent<Animator>();
        somPulo = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        float mov = Input.GetAxisRaw("Horizontal");

        if(mov == 1 ){
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.9527159F, 0.05963206F);
        }else if( mov == -1 ){
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<BoxCollider2D>().offset = new Vector2(0.9527159F, 0.05963206F);
        }

        rig.velocity = new Vector2(mov * speed, rig.velocity.y);
        animator.SetFloat("velocidade", Mathf.Abs(mov));

        if(Input.GetKeyDown(KeyCode.Space) && pulando == false){
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("pulando", true);
            pulando = true;
            somPulo.Play();
        }

        float camx = rig.transform.position.x + 3;

        if(camx < 0){
            camx = 0;
        }if(camx > 53.94F){
            camx = 53.94F;
        }
         float camy = rig.transform.position.y - 0.6F;

          if(camy < 0){
            camy = 0F;
         }if(camy > 3){
            camy = 3;
        }
        camera.position = new Vector3(camx,camy,-10);

        float fundox = (((camx - 5.6F) / 1.5F) + 10);
        fundo.position = new Vector3(fundox,0,0);
    }

    void OnCollisionEnter2D(Collision2D col){
        animator.SetBool("pulando", false);
        pulando = false;
    }
}
