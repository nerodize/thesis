private void Interpolate(float renderTime)
{
    while (_stateBuffer.Count >= 2)
    {
        State prev = _stateBuffer.Peek();
        State next = default;

        foreach (var state in _stateBuffer)
        {
            if (state.timestamp > renderTime)
            {
                next = state;
                break;
            }
            prev = state;
        }

        float t = Mathf.InverseLerp(prev.timestamp,
                                    next.timestamp,
                                    renderTime);

        if (Vector3.Distance(transform.position,
                             next.position) > positionThreshold)
            transform.position = Vector3.Lerp(prev.position,
                                              next.position, t);

        transform.rotation = Quaternion.Slerp(prev.rotation,
                                              next.rotation, t);
        return;
    }
    ApplyLatestState();
}