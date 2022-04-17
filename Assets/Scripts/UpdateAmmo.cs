using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAmmo : MonoBehaviour
{
   [SerializeField] private PlayerWeapon _weaponRef;
   private Text _text;

   private void Awake()
   {
      _text = GetComponent<Text>();
   }

   private void Update()
   {
      _text.text = _weaponRef.GetCurrentAmmo().ToString();
   }
}
