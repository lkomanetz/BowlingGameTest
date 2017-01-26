using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameTest {

	public interface IBowlingGame {

		/// <summary>
		/// Called once per complete frame.
		/// </summary>
		/// <param name="throws">Provides number of pins knocked down for each throw.</param>
		void AddFrame(params int[] throws);

		/// <summary>
		/// Called at the end of the game to retrieve the final score.
		/// </summary>
		int FinalScore { get; }

	}

}
