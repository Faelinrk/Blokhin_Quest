using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace  Quest.Player
{
    public class PlayerController : MonoBehaviour
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        private Vector3 direction;
        [SerializeField] private float speed = 2f;
        
        

        // Update is called once per frame
        void Update()
        {
            float verticalInput = Input.GetAxis(Vertical) * Time.deltaTime * speed;
            float horizotalInput = Input.GetAxis(Horizontal) * Time.deltaTime * speed;
            transform.Translate(horizotalInput,0f,verticalInput);
        }
    }
}

