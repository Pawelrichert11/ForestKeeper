using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ForestKeeper
{
    public class Game1 : Game
    {
        Texture2D background;
        Texture2D treeImage;
        Texture2D infectedImage;
        Texture2D trunkImage;
        Vector2 gameSize;
        Engine _engine;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _engine = new Engine();
            _graphics.PreferredBackBufferWidth = Constants.gameWidth;
            _graphics.PreferredBackBufferHeight = Constants.gameHeight;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            treeImage = Content.Load<Texture2D>("tree1");
            trunkImage = Content.Load<Texture2D>("trunk");
            infectedImage = Content.Load<Texture2D>("infected tree");
            background = Content.Load<Texture2D>("backgroundInGame");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState _mouseState = Mouse.GetState();
            // TODO: Add your update logic here
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                _engine.trees.ForEach(t => t.CheckClick(_mouseState.X,_mouseState.Y));
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Rectangle(0,0,Constants.gameWidth,Constants.gameHeight), Color.White);
            foreach(Tree k in _engine.trees)
            {
                switch(k.state)
                {
                    case 0: //standing tree
                        _spriteBatch.Draw(treeImage,
                            new Rectangle(k.realX,
                            k.realY,
                            Constants.TreeWidth,
                            Constants.TreeHeight
                            ),
                            Color.White);
                        break;
                    case 1: //infected tree
                        _spriteBatch.Draw(infectedImage,
                            new Rectangle(k.realX,
                            k.realY,
                            Constants.TreeWidth,
                            Constants.TreeHeight
                            ),
                            Color.White);
                        break;
                    case 2: //trunk
                        _spriteBatch.Draw(trunkImage,
                            new Rectangle(k.realX,
                            k.realY,
                            Constants.TreeWidth,
                            Constants.TreeHeight
                            ),
                            Color.White);
                        break;
                }
            }    
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
