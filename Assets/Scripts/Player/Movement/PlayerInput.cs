using UnityEngine;

namespace Player.Movement
{
    public class PlayerInput
    {
        private Vector2 _moveInput;

        public float LastPressedJumpTime { get; set; }
        public float LastPressedDashTime { get; set; }
    }
}