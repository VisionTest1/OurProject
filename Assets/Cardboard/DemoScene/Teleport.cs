// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
  private Vector3 startingPosition;

  void Start() {   //Maybe it uses only on the start time.
    startingPosition = transform.localPosition;
    SetGazedAt(false);
  }

  public void SetGazedAt(bool gazedAt) {    //while it is gaze at the cube, the cube's color changes
    GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  }

  public void Reset() {    //reset the location
    transform.localPosition = startingPosition;
  }

  public void ToggleVRMode() {  //to transform the VR mode
    Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
  }

   public void TeleportRandomly() {  
    Vector3 direction = Random.onUnitSphere;
    direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
    float distance = 2 * Random.value + 1.5f;
    transform.localPosition = direction * distance;
  }

	public void Teleport_Camera()
	{
		Vector3 direction = this.transform.position - GameObject.Find("CardboardMain").GetComponent<Transform>().position;
		GameObject.Find("CardboardMain").GetComponent<Transform>().position += direction / 10;
//		GameObject.Find("GazePointer").GetComponent<Transform>().position += direction / 10;
//		Vector3 direction = this.transform.position - GameObject.Find("Head").GetComponent<Transform>().position;
//		GameObject.Find("Head").GetComponent<Transform>().position += direction / 10;

	}
	
}
