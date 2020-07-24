using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallDebug : MonoBehaviour
{
    Rigidbody rb;
    public Text speed;
    public float force;
    public static bool debug = true;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(debug)
        {
            UnityEngine.Debug.DrawRay(transform.position, rb.velocity, Color.green);
            speed.text = "Speed: " + rb.velocity.magnitude + " m/s";
        }    
    }
    public void Up()
    {
        rb.velocity += Vector3.up * force / rb.mass;
    }
    public void Down()
    {
        rb.velocity += Vector3.down * force / rb.mass;
    }
    public void Left()
    {
        rb.velocity += Vector3.left * force / rb.mass;
    }
    public void Right()
    {
        rb.velocity += Vector3.right * force / rb.mass;
    }
    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Debug()
    {
        debug = !debug;
        speed.text = "";
    }
}
