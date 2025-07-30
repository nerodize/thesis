public Vector3? GetRewindPosition(double timestamp)
{
    BufferState? older = null, newer = null;

    foreach (var state in _buffer)
    {
        if (state.Timestamp <= timestamp)
            older = state;
        else if (state.Timestamp > timestamp)
        {
            newer = state;
            break;
        }
    }
    if (older.HasValue && newer.HasValue)
    {
        float t = (float)((timestamp - older.Value.Timestamp) /
        (newer.Value.Timestamp - older.Value.Timestamp));

        return Vector3.Lerp(older.Value.Position,
                            newer.Value.Position, t);
    }
    return older?.Position;
}