// Assigns a movie texture to the current material and plays it.

var movTexture : MovieTexture;

function Start () {
	GetComponent.<Renderer>().material.mainTexture = movTexture;
	movTexture.Play();
	movTexture.loop = true;
}