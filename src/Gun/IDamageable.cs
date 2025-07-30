if (Vector3.Distance(closestPoint, origin) < gunData.maxDistance)
{
    var damageable = targetObj.GetComponent<IDamageable>();
    damageable?.Damage(gunData.damage);
}
