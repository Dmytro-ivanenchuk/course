namespace game.Models
{
    class StandardAccount : BaseAccount
    {
        public StandardAccount(string userName, string password) : base(userName, password) { }

        public override void WinGame(BaseGame game, string opponentName)
        {
            int rating = game.CalculateRating();
            CurrentRating += rating;
            RecordGame(opponentName, "Win", rating, game.GetType().Name);
        }

        public override void LoseGame(BaseGame game, string opponentName)
        {
            int rating = game.CalculateRating();
            CurrentRating -= rating;
            RecordGame(opponentName, "Lose", rating, game.GetType().Name);
        }

        public override void DrawGame(BaseGame game, string opponentName)
        {
            int rating = 0;
            CurrentRating += rating; 
            RecordGame(opponentName, "Draw", rating, game.GetType().Name);
        }
    }

}


