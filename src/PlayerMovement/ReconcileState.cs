void ReconcileState(StatePayload rewindState)
{
    controller.enabled = false;
    transform.position = rewindState.position;
    transform.rotation = rewindState.rotation;
    _velocity = rewindState.velocity;
    controller.enabled = true;

    if (rewindState.Equals(_lastServerState)) return;

    _clientStateBuffer.Add(rewindState, rewindState.tick);
    int tickToReplay = _lastServerState.tick + 1;

    while (tickToReplay < _timer.CurrentTick)
    {
        int bufferIndex = tickToReplay % k_bufferSize;
        StatePayload statePayload = 
        ProcessMovement(_clientInputBuffer.Get(bufferIndex));
        _clientStateBuffer.Add(statePayload, bufferIndex);
        tickToReplay++;
    }
}