using BowlingGameLibrary;
using System;

namespace BowlingGameTest.UnitTests {

    public class GameRunner {
        private IBowlingGame _bowlingGame;

        public GameRunner(IBowlingGame bowlingGame) {
            _bowlingGame = bowlingGame;
        }

        public int Run(string[] frames) {
            foreach (string frame in frames) {
                // Each frame is laid out as <int>:<int>.  That's why I'm splitting on ':'
                string[] throwsStr = frame.Split(new char[] { ':' });
                int[] throws = new int[throwsStr.Length];

                for (short i = 0; i < throwsStr.Length; ++i) {
                    throws[i] = Int32.Parse(throwsStr[i]);
                }

                // This method is to be implemented by the test taker
                _bowlingGame.AddFrame(throws);
            }

            // This property is to be implemented by the test taker.
            return _bowlingGame.FinalScore;
        }

    }

}