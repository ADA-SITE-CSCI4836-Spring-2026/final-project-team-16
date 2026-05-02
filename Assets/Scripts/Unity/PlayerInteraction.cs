using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform holdPoint;
    private GameObject carriedHostage;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && carriedHostage == null)
        {
            TryPickup();
        }
    }

    void TryPickup()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 2f);

        foreach (Collider hit in hits)
        {
            Hostage hostage = hit.GetComponent<Hostage>();

            if (hostage != null && !hostage.isCollected)
            {
                carriedHostage = hostage.gameObject;
                hostage.isCollected = true;

                carriedHostage.transform.SetParent(holdPoint);
                carriedHostage.transform.localPosition = Vector3.zero;
                carriedHostage.transform.localRotation = Quaternion.identity;

                Collider col = carriedHostage.GetComponent<Collider>();
                if (col) col.enabled = false;

                Rigidbody rb = carriedHostage.GetComponent<Rigidbody>();
                if (rb) rb.isKinematic = true;

                break;
            }
        }
    }

    public GameObject DeliverHostage()
    {
        GameObject delivered = carriedHostage;

        if (carriedHostage != null)
        {
            carriedHostage.transform.SetParent(null);
            carriedHostage.SetActive(false);
            carriedHostage = null;
        }

        return delivered;
    }

    public bool HasHostage()
    {
        return carriedHostage != null;
    }
}