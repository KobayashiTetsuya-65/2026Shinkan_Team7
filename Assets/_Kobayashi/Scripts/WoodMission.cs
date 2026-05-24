using UnityEngine;

public class WoodMission : MissionObjectBase
{
    private Rigidbody rb;

    [SerializeField]
    private float yPower = 5f;

    [SerializeField]
    private float zPower = 10f;
    private Transform _tr;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void CrearAnimation()
    {
        base.CrearAnimation();
        addforce();
        _tr = transform;
    }
    private void addforce()
    {
        // Y•ûŒü‚ÆZ•ûŒü‚Ö—Í‚ð‰Á‚¦‚é
        Vector3 force = new Vector3(0, yPower, zPower);

        rb.AddForce(force, ForceMode.Impulse);

        Destroy(this.gameObject,10f);
    }
}
