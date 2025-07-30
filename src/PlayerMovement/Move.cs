void Move(Vector3 inputVector)
{
    if (DebugLogManager.IsConsoleOpen) return;
            
    _isGrounded =
        Physics.CheckSphere(groundCheck.position,
                            groundDistance,
                            groundMask);
            
     if (_isGrounded && _velocity.y < 0f)
        _velocity.y = -2f;

        Vector3 move =
            transform.right *
            inputVector.x +
            transform.forward *
            inputVector.z; 
            
        controller.Move(move * (speed * Time.fixedDeltaTime));
        
        if (playerInput.JumpPressed && _isGrounded)
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    
        _velocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(_velocity * Time.fixedDeltaTime);
}