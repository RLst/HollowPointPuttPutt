using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HollowPoint.DB
{
    public class DebugPlayer : MonoBehaviour
    {
        [SerializeField] float speed = 10f;

        // [Header("Input")]
        // [SerializeField] string horizontalAxis = "Horizontal";
        // [SerializeField] string verticalAxis = "Vertical";
        // [SerializeField] KeyCode fireButton = KeyCode.Mouse0;

        private Vector3 tp;
        [SerializeField] Gun gun;
        IInput input;

        void Start()
        {
            tp = transform.position;
            // gun = GetComponentInChildren<Gun>();
            input = GetComponent<IInput>();
        }

        void Update()
        {
            HandlePlayerFire();
            MovePlayer();
        }

        private void HandlePlayerFire()
        {
            if (input.fired) gun.Shoot();
        }

        private void MovePlayer()
        {
            tp.x += input.axis.x * speed;
            tp.z += input.axis.y * speed;
            transform.position = tp * Time.deltaTime;
            transform.rotation = input.rotation;
        }
    }
}
