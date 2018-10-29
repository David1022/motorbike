using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoControl : MonoBehaviour {

    public float velocidadRotacion = 50f;
    public float velocidadLineal = 1f;
    private float jumpForce = 50f;
    private Rigidbody2D rigidbody;
 
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    private void MueveDerecha() {
        rigidbody.velocity = new Vector2(transform.right.x * velocidadLineal, transform.right.y * velocidadLineal);
    }

    private void MueveIzquierda()
    {
        rigidbody.velocity = new Vector2(-(transform.right.x * velocidadLineal), transform.right.y * velocidadLineal);
    }

    private void RotaDerecha()
    {
        //rigidbody.AddForce(Vector2.right, ForceMode2D.Force);
        rigidbody.MoveRotation(rigidbody.rotation - velocidadLineal * Time.deltaTime);
    }

    private void RotaIzquierda()
    {
        rigidbody.MoveRotation(rigidbody.rotation + velocidadLineal * Time.deltaTime);
    }

    private void Jump() {
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            MueveIzquierda();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MueveDerecha();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RotaIzquierda();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            RotaDerecha();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        if (rigidbody.velocity.x < velocidadLineal) {
            //rigidbody.velocity = new Vector2(velocidadLineal, rigidbody.velocity.y);
        }
    }
}
