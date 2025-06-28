public struct InputPayload : INetworkSerializable
{
    public int tick;
    public Vector3 inputVector;
    public bool forceTeleport;
    public Vector3 position;
    
    public void NetworkSerialize<T>(BufferSerializer<T> serializer) 
        where T : IReaderWriter     
    {
        serializer.SerializeValue(ref tick);
        serializer.SerializeValue(ref inputVector);
        serializer.SerializeValue(ref forceTeleport);
        serializer.SerializeValue(ref position);
    }
}