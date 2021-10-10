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
    private float speed = 7.0f;
    // Game score
    private int count_score;
    public Text scoreText;
    public TextMesh winText;
    int score_to_win = 15;
    public Button nextLevel;
    public int score;

    private void Start()
    {
        this.scoreText.text = "Score: " + count_score;
        getRigidbody = this.GetComponent<Rigidbody>();
        count_score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
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
        if (other.gameObject.tag=="PickUp")
        {
            other.gameObject.SetActive(false);
            count_score++;
            setCountText();
        }
    }

    void setCountText()
    {
        this.scoreText.text = "Score: " + count_score;
        if (count_score == score_to_win)
        {
            winText.gameObject.SetActive(true);
            nextLevel.gameObject.SetActive(true);
        }
    }

    
}
