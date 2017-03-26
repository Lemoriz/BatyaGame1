using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class InputHandler
    {
        KeyboardState state;

        public void Update()
        {
            state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
            {
                // ADD SMTH LATER
            }
            if (state.IsKeyDown(Keys.Up))
            {
                up = true;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                down = true;
            }
            if (state.IsKeyDown(Keys.Left))
            {
                left = true;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                right = true;
            }
            if (state.IsKeyUp(Keys.Up))
            {
                up = false;
            }
            if (state.IsKeyUp(Keys.Down))
            {
                down = false;
            }
            if (state.IsKeyUp(Keys.Left))
            {
                left = false;
            }
            if (state.IsKeyUp(Keys.Right))
            {
                right = false;
            }



        }


        public bool left { get; private set; } = false;
        public bool right { get; private set; } = false;
        public bool up { get; private set; } = false;
        public bool down { get; private set; } = false;



    }
}
