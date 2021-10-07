using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceFighter
{
    public class TestGunCrontrol : MonoBehaviour
    {
        public Gun[] guns;
        public Transform GimbalTarget = null;
        public Text ammoType;

        //private KeyCode[] keyCodes = {
        // KeyCode.Alpha1,
        // KeyCode.Alpha2,
        // KeyCode.Alpha3,
        // KeyCode.Alpha4,
        // KeyCode.Alpha5,
        // KeyCode.Alpha6,
        // KeyCode.Alpha7,
        // KeyCode.Alpha8,
        // KeyCode.Alpha9,
        //};

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //SelectAmmo();
            getGunSelectedAmmoName();
            AttemptFireCannon();
        }

        ///<summary>
        ///Will attempt to fire the guns
        /// </summary>
        private void AttemptFireCannon()
        {
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                foreach (var gun in guns)
                {
                    if (GimbalTarget != null)
                    {
                        gun.UseGimballedAiming = true;
                        gun.GimbalTarget = GimbalTarget.position;
                    }
                    else
                    {
                        gun.UseGimballedAiming = false;
                    }
                    gun.FireSingleShot();
                }
            }
        }

        //private void SelectAmmo()
        //{
        //    int numberPressed = 0;
        //    bool keypress = false;
        //    for (int i = 0; i < keyCodes.Length; i++)
        //    {
        //        if (Input.GetKeyDown(keyCodes[i]))
        //        {
        //            numberPressed = i;
        //            Debug.Log(numberPressed);
        //            keypress = true;
        //        }
        //    }
        //    if (keypress)
        //    {
        //        keypress = false;
        //        foreach (var gun in guns)
        //        {
        //            gun.SelectAmmo(numberPressed);
        //        }
        //    }
        //}

        private void getGunSelectedAmmoName()
        {
            ammoType.text = guns[0].getAmmoType();
        }
    }
}
