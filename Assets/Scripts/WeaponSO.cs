using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    [SerializeField]
    public WeaponInfo weaponInfo;
}

[Serializable]
public struct WeaponInfo
{
    public string weaponName;
    public RenderTexture panel;
    public Material material;
    public int clipSize;
    public float fireRate;
    public float range;
    public GameObject bulletTrail;
    public VisualEffect visualEffectRef;
}
