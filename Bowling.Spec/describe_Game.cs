using NSpec;

namespace Bowling.Spec
{
    class describe_Game : nspec
    {
        Game _game;

        void when_bowling_a_complete_game()
        {
            beforeEach = () => _game = new Game();

            it["returns 0 when rolling all gutter balls"] = () =>
            {
                RollMany(20, 0);
                _game.Score.should_be(0);
            };

            it["returns 20 when rolling all ones"] = () =>
            {
                RollMany(20, 1);
                _game.Score.should_be(20);
            };

            it["handles one spare"] = () =>
            {
                RollSpare();
                _game.Roll(3);
                RollMany(17, 0);
                _game.Score.should_be(16);
            };

            it["handles one strike"] = () =>
            {
                RollStrike();
                _game.Roll(3);
                _game.Roll(4);
                RollMany(16, 0);
                _game.Score.should_be(24);
            };

            it["returns 300 on a perfect game"] = () =>
            {
                RollMany(12, 10);
                _game.Score.should_be(300);
            };
        }

        void RollMany(int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
                _game.Roll(pins);
        }

        void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        void RollStrike()
        {
            _game.Roll(10);
        }
    }
}
