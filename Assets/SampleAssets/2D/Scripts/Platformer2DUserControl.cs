using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof (PlatformerCharacter2D))]
	[RequireComponent(typeof (PlaySong))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
		private PlaySong musicInput;
        private bool jump;

		public float move = 0f;
		public bool dir = true;
		public bool addSpeed = false;
		public bool slow = false;
		public float maxSpeed = 0.5f;
		public bool stop = false;
		private int bestStreak = 0;
		private int preStreak = 0;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
			musicInput = GameObject.Find ("chart").GetComponent<PlaySong> ();
        }

        private void Update()
        {
            if(!jump)
            // Read the jump input in Update so button presses aren't missed.
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
			bestStreak = PlaySong.bestStreak;
			if (bestStreak > preStreak)
				addSpeed = true;
			if (NoteController.pause == 1 || bestStreak == 0)
				stop = true;

			float mv = move;

			if (addSpeed == true && move < maxSpeed)
				move += 0.1f;
			if (slow == true && move >= 0.1f)
				move -= 0.1f;
			if (stop == true)
				move = 0f;
			if (dir == false)
				mv = -move;
            character.Move(mv + h	, crouch, jump);
            jump = false;
			addSpeed = false;
			slow = false;
			stop = false;
			preStreak = bestStreak;
        }
			
    }
}