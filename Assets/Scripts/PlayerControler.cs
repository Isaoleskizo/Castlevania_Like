using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private bool onTheGround=false;
    static private float gravity = 9.81f;
    public float jumpForce = 2f;
    private void Update()
    {
        if(!onTheGround) 
        {
            Falling();
        }

        Moving();

        if (onTheGround && Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void Falling()
    {
        transform.Translate(Vector3.down*Time.deltaTime*gravity);
    }

    private void Moving()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 10f * Input.GetAxis("Horizontal"));
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f,25f,0f);
        //transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Terrain"))
        {
            onTheGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        onTheGround= false;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z)*Time.deltaTime);
    }
}
