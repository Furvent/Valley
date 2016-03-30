using UnityEngine;
using System.Collections;

namespace Valley.Game
{
    public class CameraHandler : MonoBehaviour
    {

        public float speed;

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            transform.position += move * speed * Time.deltaTime;
        }
    } 
}
