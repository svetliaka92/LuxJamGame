using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPoint : MonoBehaviour
{
    [SerializeField] private Light lightSource;
    [SerializeField] private Collider lightVolume;
    [SerializeField] private LightPost lightPost;

    public bool isEnabled = true;

    private void Start()
    {
        if (lightPost)
            lightPost.onInteract += OnPostInteract;
    }

    private void OnPostInteract()
    {
        if (lightPost.postType == PostType.decayed)
        {
            lightSource.intensity = 0.5f;
            lightVolume.enabled = false;
            lightVolume.gameObject.SetActive(false);

            RaycastHit[] hits = Physics.SphereCastAll(lightVolume.transform.position, 5f, Vector3.up);
            foreach (RaycastHit hit in hits)
            {
                PlayerController player = hit.collider.GetComponent<PlayerController>();
                if (player)
                {
                    player.UpdateInLight(false);
                    break;
                }
            }

            isEnabled = false;
        }

        Inventory.Instance.OnItemPicked(ShardType.small);
    }
}
