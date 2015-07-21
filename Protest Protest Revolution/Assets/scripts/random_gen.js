var projectile : Transform;
// invoke rep (take # seconds to start, then every # seconds interval
InvokeRepeating("LaunchProjectile", 0, 2);

function LaunchProjectile () {
	var randomX : float = Random.Range(-10,10);
	var randomZ : float = 2;
	
	var instance : Transform = Instantiate(projectile, new Vector3(randomX, 15, randomZ), Quaternion.identity);
	instance.transform.rotation = Random.rotation;
	//instance.velocity = Random.insideUnitSphere * 5;
}