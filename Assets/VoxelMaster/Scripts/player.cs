using UnityEngine;
using System.Collections;

namespace VoxelMaster
{
	public class player: MonoBehaviour
	{
		public static float block = 0;
		public bool locked = true;
		public float speed = 10f;
		public VoxelTerrain terrain;
		public Camera camera;
		public Transform spawn;

		float lookAnglesx;
		float lookAnglesy;
		void Update()
		{
			DoMouse();
			DoBlockBreaking();
			BlockSelection();
		}
		void DoMouse()
		{
			bool finalLocked = (Input.GetKey(KeyCode.Tab) ? false : locked);
			Cursor.lockState = (finalLocked ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !finalLocked;

			lookAnglesx += Input.GetAxis("Mouse X");
			lookAnglesy += Input.GetAxis("Mouse Y");
			lookAnglesy = Mathf.Clamp(lookAnglesy, -89, 89);

			transform.eulerAngles = new Vector3(-lookAnglesy, lookAnglesx, 0);
		}

		void BlockSelection() {
			if (Input.GetKeyDown ("1")) {
				block = 0;
			};
			if (Input.GetKeyDown ("2")) {
				block = 1;
			}
			if (Input.GetKeyDown ("3")) {
				block = 2;
			}
			if (Input.GetKeyDown ("4")) {
				block = 3;
			}
			if (Input.GetKeyDown ("5")) {
				block = 4;
			}
			if (Input.GetKeyDown ("6")) {
				block = 5;
			};
			if (Input.GetKeyDown ("7")) {
				block = 6;
			}
		}

		void DoBlockBreaking()
		{
			if (Input.GetMouseButtonDown(0)) // Destroy block
			{
				Ray r = camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
				RaycastHit hit;
				Physics.Raycast(r, out hit);

				if (hit.collider != null)
				{
					Vector3 final = hit.point - (hit.normal * 0.5f);
					terrain.RemoveBlockAt(final);
					terrain.FastRefresh();
				}
			}
			else if (Input.GetMouseButtonDown(1)) // Add dirt block
			{
				Ray r = camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
				RaycastHit hit;
				Physics.Raycast(r, out hit);

				if (hit.collider != null)
				{
					Vector3 final = hit.point + (hit.normal * 0.5f);
					terrain.SetBlockID(final, System.Convert.ToInt16(block)); //the block id
					terrain.FastRefresh();
				}
			}
		}
	}
}