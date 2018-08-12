using UnityEngine;
using System.Collections;
/// <summary
/// Particle generator.
/// 
/// The particle generator simply spawns particles with custom values. 
/// See the Dynamic particle script to know how each particle works..
/// 
/// Visit: www.codeartist.mx for more stuff. Thanks for checking out this example.
/// Credit: Rodrigo Fernandez Diaz
/// Contact: q_layer@hotmail.com
/// </summary>

public class ParticleGenerator : MonoBehaviour
{
    public int particlesSpawned = 0;
    float SPAWN_INTERVAL = 0.025f; // How much time until the next particle spawns
    float lastSpawnTime = float.MinValue; //The last spawn time
    public int PARTICLE_LIFETIME = 3; //How much time will each particle live
    public Vector3 particleForce; //Is there a initial force particles should have?
    public DynamicParticle.STATES particlesState = DynamicParticle.STATES.WATER; // The state of the particles spawned
    public Transform particlesParent; // Where will the spawned particles will be parented (To avoid covering the whole inspector with them)
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject pouringObject;

    void Start() { }

    void Update()
    {
        if (lastSpawnTime + SPAWN_INTERVAL < Time.time && particlesSpawned < 100)
        { // Is it time already for spawning a new particle?
            GameObject newLiquidParticle = (GameObject)Instantiate(Resources.Load("LiquidPhysics/DynamicParticle")); //Spawn a particle
            particlesSpawned += 1;
            newLiquidParticle.GetComponent<Rigidbody2D>().AddForce(particleForce); //Add our custom force
            DynamicParticle particleScript = newLiquidParticle.GetComponent<DynamicParticle>(); // Get the particle script
            particleScript.SetLifeTime(PARTICLE_LIFETIME); //Set each particle lifetime
            particleScript.SetState(particlesState); //Set the particle State
            newLiquidParticle.transform.position = spawner.transform.position;// Relocate to the spawner position
            newLiquidParticle.transform.parent = particlesParent;// Add the particle to the parent container			
            lastSpawnTime = Time.time; // Register the last spawnTime			
        }
    }

    void checkRotationOfPouringApparatus()
    {
        Vector3 objectEulers = pouringObject.transform.rotation.eulerAngles;
        int rotationModifier = 1;
        int baseNumberToSpawn = 1;
        if (objectEulers.z > 75 && objectEulers.z < 100)
        {
            rotationModifier = 1;
            baseNumberToSpawn = 1;
            spawnParticles(rotationModifier, baseNumberToSpawn);
        }
        else if (objectEulers.z >= 100 && objectEulers.z < 125)
        {
            rotationModifier = 2;
            baseNumberToSpawn = 2;

            spawnParticles(rotationModifier, baseNumberToSpawn);
        }
        else if (objectEulers.z >= 125 && objectEulers.z < 150)
        {
            rotationModifier = 3;
            baseNumberToSpawn = 3;

            spawnParticles(rotationModifier, baseNumberToSpawn);
        }

    }

    void spawnParticles(int rotationModifier, int baseNumberToSpawn)
    {
        //COME BACK HERE 
        if (lastSpawnTime + SPAWN_INTERVAL < Time.time && particlesSpawned < 100 && pouringManager.isPouring == true )//&& gameObject.transform.rotation.eulerAngles.z > somePredefinedSize)
        { // Is it time already for spawning a new particle?
            GameObject newLiquidParticle = (GameObject)Instantiate(Resources.Load("LiquidPhysics/DynamicParticle")); //Spawn a particle
            particlesSpawned += baseNumberToSpawn * rotationModifier ;
            newLiquidParticle.GetComponent<Rigidbody2D>().AddForce(particleForce); //Add our custom force
            DynamicParticle particleScript = newLiquidParticle.GetComponent<DynamicParticle>(); // Get the particle script
            particleScript.SetLifeTime(PARTICLE_LIFETIME); //Set each particle lifetime
            particleScript.SetState(particlesState); //Set the particle State
            newLiquidParticle.transform.position = transform.position;// Relocate to the spawner position
            newLiquidParticle.transform.parent = particlesParent;// Add the particle to the parent container			
            lastSpawnTime = Time.time; // Register the last spawnTime			
        }
    }
}
