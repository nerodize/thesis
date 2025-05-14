using Unity;
using Unity.Netcode;

public class SimpleNetworkManager : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        //kek
        if (IsServer  )  
        {
            Debug.Log("Server gestartet");
        }
        else 
        {
            Debug.Log("Client verbunden");
        }
    }

    [ServerRpc]
    public void SendMessageServerRpc(string message)
    {
        Debug.Log("Nachricht vom Client empfangen: " + message);
    }

    
    [ClientRpc]
    public void SendMessageClientRpc(string message)
    {
        Debug.Log("Nachricht vom Server empfangen: " + message);
    }
}