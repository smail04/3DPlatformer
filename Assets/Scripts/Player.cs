using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveVelocity;
    public float frictionForce;
    public float jumpForce;
    public float maxVelocity;
    public Rigidbody _rigidbody;
    public Transform bodyTransform;
    public LayerMask groundLayer;
    public Text victoryText;
    private bool isGrounded;
    private bool isCantGetUp;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !isGrounded || isCantGetUp)
        {
            bodyTransform.localScale = Vector3.Lerp(bodyTransform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 10);
            Ray rayRight = new Ray(bodyTransform.position + new Vector3(0.5f, 0, 0), bodyTransform.up);
            Ray rayLeft = new Ray(bodyTransform.position + new Vector3(-0.5f, 0, 0), bodyTransform.up);
            float height = 1.5f;
            isCantGetUp = Physics.Raycast(rayRight, height, groundLayer) || Physics.Raycast(rayLeft, height, groundLayer);
        }
        else
            bodyTransform.localScale = Vector3.Lerp(bodyTransform.localScale, new Vector3(1, 1f, 1), Time.deltaTime * 10);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
                _rigidbody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }

        if (transform.position.y < 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            ReloadScene();
        }
    }

    void FixedUpdate()
    {
        float speedMultiplier = 1;

        float inputAxisHorizontal = Input.GetAxis("Horizontal");

        if (!isGrounded)
        {
            speedMultiplier = 0.3f;
            if (_rigidbody.velocity.x > maxVelocity && inputAxisHorizontal > 0
                || _rigidbody.velocity.x < -maxVelocity && inputAxisHorizontal < 0)
                speedMultiplier = 0;
        }

        _rigidbody.AddForce(new Vector3(inputAxisHorizontal * moveVelocity * speedMultiplier, 0,0), ForceMode.VelocityChange);

        if (isGrounded)
            _rigidbody.AddForce(-_rigidbody.velocity.x * frictionForce, 0, 0, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckGround(collision);
    }   

    private void OnCollisionStay(Collision collision)
    {
        CheckGround(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void CheckGround(Collision collision)
    {
        foreach (ContactPoint c in collision.contacts)
            if (Vector3.Angle(c.normal, transform.up) < 45)
                isGrounded = true;
    }

    public void Die()
    {
        ReloadScene();
    }

    private void ReloadScene()
    {
        Enemy.RemoveAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
