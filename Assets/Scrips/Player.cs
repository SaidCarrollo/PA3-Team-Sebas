using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject Fitgh;
    public GameObject Inventario;
    public float Vida;
    public TextMeshProUGUI Vid;
    public TextMeshProUGUI Puntaje;
    public float PUn;
    public Transform[] nodos;
    private int puntoactual = 0;
    public float sigui;

    public float parado;
    public bool quieto;
    void Start()
    {
        parado = 1;
        sigui = calcu();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        momm();
      /*  movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");*/
        // transform.position=new Vector2()
        if (Vida ==0)
        {
            Destroy(this.gameObject);
        }
        if (quieto == false)
        {
            parado = parado + Time.deltaTime;
        }
        if (parado >= 2)
        {
            moveSpeed = 5;
            parado = 0;
            quieto = true;
        }
     
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
            Fitgh.SetActive(true);
            Vida -= 1;
            PUn = PUn + 10;
            Vid.text = "Vida: " + Vida;
            Puntaje.text = "Puntaje " + PUn;
            moveSpeed=0;

            quieto = false;

        }
        if (collision.gameObject.tag == "node")
        {
            if (puntoactual < 14)
            {
                puntoactual = puntoactual + 1;
            }else 
            {
                puntoactual = puntoactual;
            }
          
        }
        if (collision.gameObject.tag == "Win")
        {

            SceneManager.LoadScene("Victoria");

        }
    }
    public float calcu()
    {
        Vector2 dis = nodos[(puntoactual + 1) % nodos.Length].position - transform.position;
        return dis.magnitude/moveSpeed;
    }
    public void momm()
    {
        transform.position = Vector2.MoveTowards(transform.position, nodos[puntoactual].position, moveSpeed * Time.deltaTime);
        //puntoactual += 1;
        //nodos[]=nodos[puntoactual + 1];
    }
  
}
