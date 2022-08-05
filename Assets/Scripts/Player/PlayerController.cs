using System;
using System.Collections;
using UnityEngine;

namespace  Quest.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header(("Move"))]
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        private const string Jump = "Jump";
        private float verticalInput;
        private float horizotalInput;
        private CharacterController controller;
        [SerializeField] private float speed = 2f;

        //Gravity
        private const float gravity = -9.8f;
        private Vector3 velocity;
        [SerializeField] private Transform legs;
        [SerializeField] private float legsRadius=0.04f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float jumpPower = .07f; 

        [Header("Shooting")] 
        [SerializeField] private Transform bulletPoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject landMinePrefab;
        
        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
            Shoot();
        }

        private void Move()
        {
            bool onGround = Physics.CheckSphere(legs.position, legsRadius, groundMask);
            if (Input.GetButtonDown(Jump) && onGround)
                velocity.y += jumpPower;
            else
            {
                if (onGround) velocity.y = -.05f;
                else velocity.y += gravity * Mathf.Pow(Time.deltaTime, 2);
                verticalInput = Input.GetAxis(Vertical) * Time.deltaTime * speed;
                horizotalInput = Input.GetAxis(Horizontal) * Time.deltaTime * speed;
            }
            Vector3 move = horizotalInput * transform.right + verticalInput * transform.forward + velocity;
            controller.Move(move);
        }

        private void Shoot()
        {
            if (Input.GetMouseButtonDown(0))//Shooting
            {
                GameObject bullet = Instantiate(bulletPrefab,bulletPoint.transform.position,bulletPoint.transform.rotation);
            }

            if (Input.GetMouseButtonDown(1))//Landmines
            {
                GameObject landMine = Instantiate(landMinePrefab,bulletPoint.transform.position,Quaternion.identity);
            }
        }
    }
}