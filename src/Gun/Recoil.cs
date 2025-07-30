class GunSway
{
    public void ApplyRecoil(Vector3 positionKickback,
                            Vector3 rotationKickback)
    {
        _recoilOffset += positionKickback;
        _recoilRotation *= Quaternion.Euler(rotationKickback);
    }

}

class Gun
{
    void Recoil()
    {
        gunSway?.ApplyRecoil(new Vector3(0, 0, -0.05f),
                             new Vector3(-2f, 1f, 0f));
    }
}