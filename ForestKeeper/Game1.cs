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
        Texture2D seedlingImage;
        Texture2D numbersImage;
        Engine _engine;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        MouseState lastMouseState;
        MouseState currentMouseState;

        float timer = 0;
        int points = 0;
        int clicks = 40;
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
            seedlingImage = Content.Load<Texture2D>("seedling");
            infectedImage = Content.Load<Texture2D>("infected tree");
            background = Content.Load<Texture2D>("backgroundInGame");
            numbersImage = Content.Load<Texture2D>("numbers");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Tree.AliveTrees == 0)
                Exit(); // to be changed
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed)
            {
                clicks -= 1;
                if (currentMouseState.X>Constants.GameBorderLeft&&
                    currentMouseState.X<Constants.insideFenceX + Constants.GameBorderLeft&&
                    currentMouseState.Y>Constants.GameBorderTop&&
                    currentMouseState.Y<Constants.GameBorderTop + Constants.insideFenceY
                    )
                {
                    //to be optimised by changing List of trees into an array of trees
                    if (clicks > 0)
                    {
                        _engine.trees.ForEach(t =>
                        {
                            if (t.CheckClick(currentMouseState.X, currentMouseState.Y))
                            {
                                points += 1;
                                clicks += 2;
                            }
                        });
                    }
                }
            }
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer>(Constants.InfectionSpeed/13)*Tree.AliveTrees+0.3)
            {
                timer = 0;
               _engine.InfectATree();
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
                    case 3: //seedling
                        _spriteBatch.Draw(seedlingImage,
                            new Rectangle(k.realX+ Constants.SeedlingWidth/2,
                            k.realY + Constants.SeedlingHeight/2,
                            Constants.SeedlingWidth,
                            Constants.SeedlingHeight
                            ),
                            Color.White);
                        break;
                }
            }
            //drawing points, clicks and time
            for(int i=0;i<4;i++)
            {
                _spriteBatch.Draw(numbersImage,
                     new Rectangle(Constants.ClickPos.Item1 + Constants.NumberSize.Item1 * i,
                     Constants.ClickPos.Item2,
                     Constants.NumberSize.Item1, Constants.NumberSize.Item2),
                     new Rectangle(SpriteManager.Number(clicks)[i*2], SpriteManager.Number(clicks)[i * 2 + 1], 100, 140),
                     Color.White);
                _spriteBatch.Draw(numbersImage,
                     new Rectangle(Constants.PointPos.Item1 + Constants.NumberSize.Item1 * i,
                     Constants.PointPos.Item2,
                     Constants.NumberSize.Item1, Constants.NumberSize.Item2),
                     new Rectangle(SpriteManager.Number(points)[i * 2], SpriteManager.Number(points)[i * 2 + 1], 100, 140),
                    Color.White);
                if (i < 2)
                {
                    _spriteBatch.Draw(numbersImage,
                         new Rectangle(Constants.TimePos.Item1 + Constants.NumberSize.Item1 * i,
                         Constants.TimePos.Item2,
                         Constants.NumberSize.Item1, Constants.NumberSize.Item2),
                         new Rectangle(SpriteManager.Time((int)gameTime.TotalGameTime.TotalSeconds)[i * 2], SpriteManager.Time((int)gameTime.TotalGameTime.TotalSeconds)[i * 2 + 1], 100, 140),
                         Color.White);
                }
                else
                {
                    _spriteBatch.Draw(numbersImage,
                      new Rectangle(Constants.TimePos.Item1 + Constants.NumberSize.Item1 * i + 25,
                      Constants.TimePos.Item2,
                      Constants.NumberSize.Item1, Constants.NumberSize.Item2),
                      new Rectangle(SpriteManager.Time((int)gameTime.TotalGameTime.TotalSeconds)[i * 2], SpriteManager.Time((int)gameTime.TotalGameTime.TotalSeconds)[i * 2 + 1], 100, 140),
                      Color.White);
                }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
