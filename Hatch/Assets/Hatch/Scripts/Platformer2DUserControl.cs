using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private float h;
        private bool ableToJump;
        public delegate void InteractAction();
        public static event InteractAction Interact;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetKey(KeyCode.Space);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                m_Character.ClimbLedge();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                m_Character.DismountLedge();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                h = -1.0f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                h = 1.0f;
            }
            else
            {
                h = 0.0f;
            }
            // Pass all parameters to the character control script.
            
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
