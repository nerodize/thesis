void Shoot()
{
    if (gunData.currentAmmo <= 0
        || !CanShoot()
        || _playerCamera == null) return;

    var camOrigin =
        _playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
    var camDirection = _playerCamera.transform.forward;

    if (Physics.Raycast(camOrigin,
                        camDirection,
                        out RaycastHit camHit,
                        gunData.maxDistance,
                        hitMask))
    {
        ulong targetId =
            camHit
            .transform
            .GetComponent<NetworkObject>()?
            .NetworkObjectId ?? 0;

        ShootServerRpc(camOrigin,
                       camDirection,
                       targetId,
                       NetworkManager
                       .ServerTime
                       .Time - NetworkManager.LocalTime.Time);

        bulletManager.SpawnBulletHole(camHit,
                                      new Ray(camOrigin, camDirection));
    }

    gunData.currentAmmo--;
    _timeSinceLastShot = 0f;
    OnGunShot();
}
