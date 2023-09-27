using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrePhoton
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float movementSpeed = 3f;

        private void Update()
        {
            HandleMovement();
        }

        void HandleMovement()
        {
            Vector2 movementVector;
            Vector2 userInput;

            userInput.x = Input.GetAxisRaw("Horizontal");
            userInput.y = Input.GetAxisRaw("Vertical");

            movementVector = userInput * movementSpeed;

            transform.position += (Vector3)movementVector * Time.deltaTime;
        }

        public void Restart()
        {
            transform.position = Vector3.zero;
        }
    }
}
