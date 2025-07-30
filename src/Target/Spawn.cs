class Spawner
{
    private void Respawn()
    {
        Vector3 randomPosition = GetRandomPositionInArea();

        var targetInstance =
                Instantiate(targetPrefab,
                            randomPosition,
                            Quaternion.identity);
        targetInstance.GetComponent<NetworkObject>().Spawn();
    }

    private Vector3 GetRandomPositionInArea()
    {
        float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float z = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);
        return spawnAreaCenter + new Vector3(x, 0f, z);
    }

    public IEnumerator RespawnDelayed()
    {
        yield return new WaitForSeconds(2f);
        Respawn();
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            Respawn();
        }
    }
}