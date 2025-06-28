void HandleServerReconciliation()
{
    if (_lastServerState.tick <= 1) return;
    if (!ShouldReconcile()) return;

    int bufferIndex = _lastServerState.tick % k_bufferSize;
    if (bufferIndex - 1 < 0) return;

    StatePayload rewindState = IsHost
        ? _serverStateBuffer.Get(bufferIndex - 1)
        : _lastServerState;

    float positionError = Vector3.Distance(
        rewindState.position,
        _clientStateBuffer.Get(bufferIndex).position
    );

    if (positionError > reconciliationThreshold)
    {
        Debug.Break();
        ReconcileState(rewindState);
    }

    _lastProcessedState = _lastServerState;
}