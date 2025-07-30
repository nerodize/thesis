public class Gun
{
    private void Update()
    {
        if (!IsOwner) return;
        if (InputState.InputLocked) return;

        _timeSinceLastShot += Time.deltaTime;
        UpdateAmmoUI();
        UpdateHitmarker();
    }
    

    public bool CanShoot() =>
            !gunData.isReloading && _timeSinceLastShot >
            1f / (gunData.fireRate / 60f);
}