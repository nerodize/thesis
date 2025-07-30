void Extrapolate()
{
    if (IsServer && _extrapolationCooldown.IsRunning)
    {
        transform.position = _extrapolationState.position.With(y: 0); 
    }

void HandleExtrapolation(StatePayload latest, float latency) {
    if (ShouldExtrapolate(latency)) {
        if (_extrapolationState.position != default) {
            latest = _extrapolationState;
        }

        var posAdjustment = latest.velocity * 
            (1 + latency * extrapolationMultiplier);
        _extrapolationState.position =  
            latest.position + posAdjustment;
        _extrapolationState.rotation = latest.rotation;             
        _extrapolationState.velocity = latest.velocity;
        _extrapolationCooldown.Start();
        } else {
            _extrapolationCooldown.Stop();
        }
    }
}