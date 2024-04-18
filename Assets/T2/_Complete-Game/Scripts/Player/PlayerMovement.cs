using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 6f;            // The speed that the player will move at.

        public SkinnedMeshRenderer playerMaterial;
        public Material material;
        //============================================================================
        Vector3 movement;                   // Variable de vector3 que usaremos para almacenar la direccion del movimiento del jugador
        //============================================================================
        Rigidbody playerRigidbody;          // Variable del Rigidbody
        Animator anim;                      // Reference to the animator component.
        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.

        void Awake ()
        {
            // Create a layer mask for the floor layer.
            floorMask = LayerMask.GetMask ("Floor");

            // Set up references.
            anim = GetComponent <Animator> ();
            //Referencia del Rigidbody del player
            playerRigidbody = GetComponent <Rigidbody> ();
        }


        void FixedUpdate ()
        {
            // Store the input axes.
            float movementHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            float movementVertical = CrossPlatformInputManager.GetAxisRaw("Vertical");

            // Move the player around the scene.
            Move(movementHorizontal, movementVertical);

            // Turn the player to face the mouse cursor.
            Turning();

            // Animate the player.
            Animating(movementHorizontal, movementVertical);
        }

        //======================================================================
        //Añadir Movimiento
        void Move (float h, float v)
        {
            //crear el vector de movimiento
            movement = new Vector3(h, 0f, v);
            //realizar el movimiento, se le recomienda utilizar el movimiento mas "preciso" visto en clase
            playerRigidbody.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);
        }
        //======================================================================

        void Turning ()
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit floorHit;

            // Perform the raycast and if it hits something on the floor layer...
            if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = floorHit.point - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);

                // Set the player's rotation to this new rotation.
                playerRigidbody.MoveRotation (newRotatation);
            }
        }


        void Animating (float h, float v)
        {
            // Create a boolean that is true if either of the input axes is non-zero.
            bool walking = h != 0f || v != 0f;

            // Tell the animator whether or not the player is walking.
            anim.SetBool ("IsWalking", walking);
        }
        //=====================================
        //Modificadores
        //=====================================
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Modificators"))
            {
                switch (other.name)
                {
                    case "DoubleDamage":
                        Bullet.damagePerShot *= 2;
                        break;
                    case "HalfReductionTimeBetweenBullets":
                        PlayerShooting.timeBetweenBullets /= 2;
                        break;
                    case "ChangeMaterial":
                        Debug.Log("mat");
                        playerMaterial.material = material;
                        break;
                }
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Tramps"))
            {
                switch (other.name)
                {
                    case "HalfDamage":
                        Bullet.damagePerShot /= 2;
                        break;
                }
            }
        }
        //=====================================
        //Trampas
        //=====================================
    }
}