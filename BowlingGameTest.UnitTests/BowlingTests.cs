using BowlingGameTest;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest.UnitTests {

	[TestClass]
	public class BowlingTests {
		private IBowlingGame _bowlingGame;

		[TestInitialize]
		public void Initialize() {
			_bowlingGame = GetBowlingGame();
		}

		[TestMethod]
		public void PerfectScore() {
			string game = "10:0, 10:0, 10:0, 10:0, 10:0, 10:0, 10:0, 10:0, 10:0, 10:10:10";
			AssertScore(game, 300);
		}

		[TestMethod]
		public void NoScore() {
			string game = "0:0,0:0,0:0,0:0,0:0,0:0,0:0,0:0,0:0,0:0:0";
			AssertScore(game, 0);
		}

		[TestMethod]
		public void AllSpares() {
			string game = "5:5,5:5,5:5,5:5,5:5,5:5,5:5,5:5,5:5,5:5:10";
			AssertScore(game, 155);
		}

		[TestMethod]
		public void StrikesAndSparesAlternating() {
			string game = "10:0,5:5,10:0,5:5,10:0,5:5,10:0,5:5,10:0,5:5:10";
			AssertScore(game, 200);
			game = "5:5,10:0,5:5,10:0,5:5,10:0,5:5,10:0,5:5,10:5:5";
			AssertScore(game, 200);
		}

		[TestMethod]
		public void OneTurkeyInGame() {
			string game = "3:5,1:4,10:0,10:0,10:0,4:3,4:4,2:6,5:4,5:1:0";
			AssertScore(game, 122);
		}

		[TestMethod]
		public void ThreeSparesInARow() {
			string game = "4:4,1:5,5:5,5:5,5:5,6:2,7:1,1:5,4:3,3:2:0";
			AssertScore(game, 94);
		}

		[TestMethod]
		public void ThreeSparesOfDifferentValuesInARow() {
			string game = "2:3,8:2,1:9,3:7,5:4,3:3,7:1,8:0,3:1,5:4:0";
			AssertScore(game, 88);
		}

		[TestMethod]
		public void StrikesAndGutterBallsAlternating() {
			string game = "10:0,0:0,10:0,0:0,10:0,0:0,10:0,0:0,10:0,0:0:0";
			AssertScore(game, 40);
		}

		[TestMethod]
		public void SparesAndGutterBallsAlternating() {
			string game = "5:5,0:0,5:5,0:0,5:5,0:0,5:5,0:0,5:5,0:0:0";
			AssertScore(game, 40);
		}

		[TestMethod]
		public void SparesAndStrikesPepperedIn() {
			string game = "3:2,6:4,2:2,10:0,10:0,7:3,8:2,3:2,9:0,10:6:4";
			AssertScore(game, 133);
		}

		[TestMethod]
		public void ThreeSparesOfVaryingValuesInARow() {
			string game = "3:2,6:1,8:2,5:5,4:6,0:0,1:8,6:0,5:0,2:5:0";
			AssertScore(game, 78);
		}

		private IBowlingGame GetBowlingGame() {
			return null;
		}

		private void AssertScore(string fullGame, int expectedScore) {
			string[] frames = fullGame.Split(new char[] { ',' });
			GameRunner runner = new GameRunner(_bowlingGame);
			int gameScore = runner.Run(frames);

			Assert.IsTrue(
				gameScore == expectedScore,
				$"Expected Score: {expectedScore}\nActual Score: {gameScore}"
			);
		}

	}

}
