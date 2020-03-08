using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPoint : MonoBehaviour
{
    [SerializeField] private Light lightSource;
    [SerializeField] private Collider lightVolume;
    [SerializeField] private LightPost lightPost;

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
        }

        Inventory.Instance.OnItemPicked(ShardType.small);
    }
}
