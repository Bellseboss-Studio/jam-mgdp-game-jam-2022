using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

namespace GameAudio
{
    public class UIPerdurableValues : Singleton<UIPerdurableValues>
    {
        public static float MasterFaderValue
        {
            get => PlayerPrefs.GetFloat("MasterFaderValue");
            set => PlayerPrefs.SetFloat("MasterFaderValue", value);
        }

        public static float MxFaderValue
        {
            get => PlayerPrefs.GetFloat("MxFaderValue");
            set => PlayerPrefs.SetFloat("MxFaderValue",value);
        }
        
        public static float SfxFaderValue
        {
            get => PlayerPrefs.GetFloat("SfxFaderValue");
            set => PlayerPrefs.SetFloat("SfxFaderValue", value);
        }

        public static float DxFaderValue
        {
            get => PlayerPrefs.GetFloat("DxFaderValue");
            set => PlayerPrefs.SetFloat("DxFaderValue", value);
        }
    }

}