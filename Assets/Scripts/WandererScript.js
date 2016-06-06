// Public variable that contains the speed of the enemy
public var speed : int = -5;

// Function called when the enemy is created
function Start () {
    // Get the rigidbody component
    var r2d = GetComponent("Rigidbody2D");

    // Add a vertical speed to the enemy
    r2d.velocity.y = speed;

}

// Function called when the enemy collides with another object
function OnTriggerEnter2D(obj) {
    // Name of the object that collided with the enemy
    var name = obj.gameObject.name;

    // If the enemy collided with a bullet
    if (name == "bullet(Clone)") {
        // Destroy itself (the enemy) and the bullet
        Destroy(gameObject);
        Destroy(obj.gameObject);
    }

    // If the enemy collided with the spaceship
    if (name == "Player") {
        // Destroy itself (the enemy) to keep things simple
        Destroy(gameObject);
    }
} 

// Function called when the object goes out of the screen
function OnBecameInvisible() {
    // Destroy the enemy
    Destroy(gameObject);
} 