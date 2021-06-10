using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject object;
    public float horizontal_power = 7.5F;
    public float vertical_power = 10;
    public float jump_power = 25;
    public float boostmult = 5;
    public float nyom = 0.5F;
    public float Currentspeed = 0;
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        RB.AddRelativeForce(Vector3.forward * (Input.GetButton("sprint") ? vertical_power * boostmult : vertical_power) * Input.GetAxis("Vertical"));
        RB.AddRelativeTorque(0, Input.GetAxis("turn") * nyom, 0);
        RB.AddRelativeForce(Vector3.right * horizontal_power * Input.GetAxis("right"));
        RB.AddRelativeForce(Vector3.left * horizontal_power * Input.GetAxis("left"));
        RB.AddRelativeForce(Vector3.up * jump_power * Input.GetAxis("jump"));
        RB.AddRelativeForce(Vector3.down * jump_power * Input.GetAxis("ground"));
        Currentspeed = RB.velocity.magnitude;
    }
    void OnCollisionEnter(Collision collision)
    {
       object.SetActive(true);
    }
    // UwU
}
