namespace BowlingGameLibrary {

    public interface IBowlingGame {

        // Called once per complete frame.
        void AddFrame(params int[] throws);

        int FinalScore { get; }

    }

}
