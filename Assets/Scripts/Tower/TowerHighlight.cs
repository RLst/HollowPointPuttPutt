/************************************************************************************
Filename    :   TowerHighlight.cs
Content     :   LipSync Demo controls
Created     :   July 11, 2018
Copyright   :   Copyright Facebook Technologies, LLC and its affiliates.
                All rights reserved.

Licensed under the Oculus Audio SDK License Version 3.3 (the "License");
you may not use the Oculus Audio SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

https://developer.oculus.com/licenses/audio-3.3/

Unless required by applicable law or agreed to in writing, the Oculus Audio SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
************************************************************************************/
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    public class TowerHighlight : MonoBehaviour
    {
        Tower[] towers;
        // LayerMask towerLayer;
        Gun gun;

        void Awake()
        {
            //Find and store all towers
            towers = FindObjectsOfType<Tower>();    

            //Cache gun
            gun = GetComponentInChildren<Gun>();
        }

        void Update()
        {
            HandleTowerHighlighting();
        }

        void HandleTowerHighlighting()
        {
            //Check gun's ray cast to see if it's hitting a tower
            int layermask = 1 << 8;
            layermask = ~layermask;
            if (gun.Raycast<Tower>(out Tower hit, layermask))
            {
                hit.shouldBeLit = true;
            }

            //Otherwise unhighlight everything
            UnhighlightAllTowers();
        }

        public void UnhighlightAllTowers()
        {
            foreach (var t in towers)
            {
                t.shouldBeLit = false;
            }
        }
    }
}