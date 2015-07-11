using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	//fields seen in the Inspector panel
	public GameObject prefabProjectile;
	public float shotMult = 4.0f;
    public float moveSpeed = 1.0f;
    public float moveShotSuspression = 2f;
    public float camResetThreshold = 2f;

	// Internal variable
	private GameObject launchPoint;
	private Vector3 launchPos;
	private GameObject projectile;
    private Rigidbody slingshotRB;
    private float lastShotTime = 0;
    private Animator animation;

	bool aimingMode;

	void Awake(){
        animation = GetComponentInChildren<Animator>();
        Transform launchPointTransform = transform.FindChild("LaunchDirection");
		launchPoint = launchPointTransform.gameObject;
        slingshotRB = GetComponent<Rigidbody>();
		launchPos = launchPointTransform.position;
	}

	void Update() {

        if(Input.GetButtonDown("Jump"))
        {
            projectile = Instantiate(prefabProjectile, launchPoint.transform.position, Quaternion.identity) as GameObject;
            Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.isKinematic = false;
            projectileRB.velocity = launchPoint.transform.forward * shotMult + slingshotRB.velocity / moveShotSuspression;
            lastShotTime = Time.time;
            animation.SetTrigger("Shoot");

            followCam.S.poi = projectile;
        }

        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            print(Time.time - lastShotTime);
            slingshotRB.AddForce(transform.right * Input.GetAxis("Horizontal") * moveSpeed);
            if(Time.time - lastShotTime > camResetThreshold)
            {
                followCam.S.poi = this.gameObject;
            }
        }


	}	
}