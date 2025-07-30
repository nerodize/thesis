public class Target : NetworkBehaviour, IDamageable
{
    private struct BufferState
    {
        public Vector3 Position;
        public double Timestamp;
    }
    private readonly List<BufferState> _buffer = new();
    private const float BufferTime = 1.0f;

    private void FixedUpdate()
    {
        if (!IsServer) return;

        _buffer.Add(new BufferState
        {
            Position = transform.position,
            Timestamp = NetworkManager.ServerTime.Time
        });

        _buffer.RemoveAll(state => NetworkManager.ServerTime.Time -
                                   state.Timestamp > BufferTime);
    }
}