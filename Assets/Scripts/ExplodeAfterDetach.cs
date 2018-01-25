/*
 * Copyright © 2018, Meta Company.  All rights reserved.
 *
 * Redistribution and use of this software (the "Software") in source and binary forms,
 * with or without modification, is permitted provided that the following conditions are met:
 *
 * 1. Redistributions in source code must retain the above copyright notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer
 *    in the documentation and/or other materials provided with the distribution.
 * 3. The name of Meta Company (“Meta”) may not be used to endorse or promote products derived from this software without specific
 *    prior written permission from Meta.
 * 4. LIMITATION TO META PLATFORM: Use of the Software and of any and all libraries (or other software) incorporating the Software
 *    (in source or binary form) is limited to use on or in connection with Meta-branded devices or Meta-branded software development kits.
 *    For example, a bona fide recipient of the Software may modify and incorporate the Software into an application limited to use on or in
 *    connection with a Meta-branded device, while he or she may not incorporate the Software into an application designed or offered for use
 *    on a non-Meta-branded device.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDER "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL META COMPANY BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE
 * GOODS OR SERVICES; LOSS OF USE, DATA OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.Collections;
using UnityEngine;

public class ExplodeAfterDetach : MonoBehaviour
{
    [SerializeField] private GameObject _explodeGameObject;
    [SerializeField] private GameObject _disableOnExplode;
    [SerializeField] private float _explodeTime = 2.5f;
    [SerializeField] private float _destoryTime = 1.5f;

    private Coroutine _explodeRoutine;

    public void Detach()
    {
        if (_explodeRoutine != null)
        {
            return;
        }

        _explodeRoutine = StartCoroutine(ExplodeRoutine());
    }

    IEnumerator ExplodeRoutine()
    {
        var timeCounter = 0.0f;
        while (timeCounter < _explodeTime)
        {
            timeCounter += Time.deltaTime;
            yield return null;
        }

        Explode();
    }

    private void Explode()
    {
        if (_explodeGameObject != null)
        {
            _explodeGameObject.SetActive(true);
        }

        if (_disableOnExplode != null)
        {
            _disableOnExplode.SetActive(false);
        }
        
        StartCoroutine(DestroyRoutine());
    }

    IEnumerator DestroyRoutine()
    {
        var timeCounter = 0.0f;
        while (timeCounter < _destoryTime)
        {
            timeCounter += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
