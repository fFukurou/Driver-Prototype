using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 290.0f;
    [SerializeField] float moveSpeed = 32.0f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 64f;
    [SerializeField] float boostTime = 2f;

    float timer = 0;
    bool timerReached = false;
    bool timerStarted = false;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0);

        if (!timerReached && timerStarted)
        {
            timer += Time.deltaTime;
        }
        if (!timerReached && timer > boostTime)
        {
            moveSpeed = 32f;
            timerStarted = false;
            timerReached = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Booster")
        {
            moveSpeed = boostSpeed;
            Destroy(other.gameObject);
            timer = 0;
            timerStarted = true;
            timerReached = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        timer = boostTime / 2;
        timerStarted = true;
        timerReached = false;
    }


}



