using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Player movement
    private Rigidbody getRigidbody;
    private float horizontal_input;
    private float vertical_input;
    private float speed = 10.0f;
    // Game score
    private int count_score;
    public Text Count;
    Text win_text;
    int score_to_win = 14;

    private void Start()
    {
        getRigidbody = this.GetComponent<Rigidbody>();
        count_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_input = Input.GetAxis("Horizontal");
        vertical_input = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(horizontal_input, 0, vertical_input);
        force *= speed;
        getRigidbody.AddForce(force);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Count.text = "Score: " + count_score;
        if (other.gameObject.tag=="PickUp")
        {
            other.gameObject.SetActive(false);
            count_score++;
            setCountText();
        }
    }

    void setCountText()
    {
        
        if (count_score == score_to_win)
        {

        }
    }

}
