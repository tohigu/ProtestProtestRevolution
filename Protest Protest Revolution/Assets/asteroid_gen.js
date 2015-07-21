// Starting in 2 seconds.
// a projectile will be launched every 0.3 seconds

var projectile : Transform;

InvokeRepeating("LaunchProjectile", 2, 2);

function LaunchProjectile () {
	var randomX : float = Random.Range(-10,10);
	var randomZ : float = Random.Range(-10,10);
	
	var instance : Transform = Instantiate(projectile, new Vector3(randomX, 15, randomZ), Quaternion.identity);
	//instance.velocity = Random.insideUnitSphere * 5;
}