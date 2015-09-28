using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    // For changing the crosshair to show
    // that we've shot a bullet
    [SerializeField]
    private Image crosshair;
    private Vector2 baseCrosshairSize;

    // For playng a sound effect
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioClip gunshot;

    public int damage = 1;

    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        baseCrosshairSize = crosshair.rectTransform.sizeDelta;
    }

    void Update()
    {
        if (Input.GetButtonDown(AxisCodes.Fire1))
        {
            ShootVertically();
        }
    }

    private IEnumerator gunshotEffect()
    {
        crosshair.rectTransform.sizeDelta = 2 * baseCrosshairSize;

        soundSource.PlayOneShot(gunshot);

        yield return new WaitForSeconds(0.1f);

        crosshair.rectTransform.sizeDelta = baseCrosshairSize;
    }

    private void ShootForward()
    {
        var middleOfScreen = new Vector3(
            _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

        var coords = new List<Vector3>();
        coords.Add(middleOfScreen);

        searchAndAttackObjects(coords, 1);
    }

    /// <summary>
    /// Does multiple raycasts across the entire vertical axis.
    /// 
    /// To be used when the y axis is locked like Doom.
    /// </summary>
    private void ShootVertically()
    {
        var coords = new List<Vector3>();
        var xPos = _camera.pixelWidth / 2;
        var zPos = 0;
        for (var i = 0.1f; i < 1f; i += 0.05f)
        {
            var yPos = i * _camera.pixelHeight;
            var coord = new Vector3(xPos, yPos, zPos);
            coords.Add(coord);
        }

        searchAndAttackObjects(coords, 1);
    }

    private void searchAndAttackObjects(List<Vector3> coords, int hits)
    {
        var hitObjects = Raycasting.raycastsThroughScreen(coords, _camera);

        var numHits = 0;
        foreach (var hitObject in hitObjects)
        {
            var target = hitObject.GetComponent<ShootableTarget>();
            if (target)
            {
                StartCoroutine(gunshotEffect());

                if (target.ReactToHit(damage))
                {
                    soundSource.PlayOneShot(target.deathClip);
                }

                numHits += 1;
            }

            if (numHits >= hits)
            {
                break;
            }
        }

        if (numHits == 0)
        {
            StartCoroutine(gunshotEffect());
        }
    }
}
