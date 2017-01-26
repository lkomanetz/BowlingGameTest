using BowlingGameTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameTest.UnitTests {

	public class GameRunner {
		private IBowlingGame _bowlingGame;

		public GameRunner(IBowlingGame bowlingGame) {
			_bowlingGame = bowlingGame;
		}

		public int Run(string[] frames) {
			foreach (string frame in frames) {
				// Each frame is laid out as <int>:<int>.  That's why I'm Splitting on the ':' character.
				int[] throws = Array.ConvertAll(
					frame.Split(new char[] { ':' }),
					(str) => Int32.Parse(str)
				);

				// This method is to be implemented by the test taker.
				_bowlingGame.AddFrame(throws);
			}

			// This property is to be implemented by the test taker.
			return _bowlingGame.FinalScore;
		}

	}

}
