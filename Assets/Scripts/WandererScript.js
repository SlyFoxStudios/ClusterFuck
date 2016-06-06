// Public variable that contains the speed of the enemy
public var speed : int = -5;

// Function called when the enemy is created
function Start () {
    // Get the rigidbody component
    var r2d = GetComponent("Rigidbody2D");

    // Add a vertical speed to the enemy
    r2d.velocity.y = speed;

}

// Function called when the object goes out of the screen
function OnBecameInvisible() {
    // Destroy the enemy
    Destroy(gameObject);
} 