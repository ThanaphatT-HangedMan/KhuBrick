using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Char.Content.Model;
using Char.Content.Sprites;

namespace Char
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _sprites;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


          
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var playerTexture = Content.Load<Texture2D>("Testๆ");
            //var blockTexture = Content.Load<Texture2D>("");
            _sprites = new List<Sprite>()
      {

        new Sprite(playerTexture)
        {
          Input = new Input()
          {

          },
          Position = new Vector2(100, 100),
          Colour = Color.Red,
        },

        new Player(playerTexture)
        {
            Input = new Input()
          {
            Left = Keys.Left,
            Right = Keys.Right,
            Space = Keys.Space,

            },
          Position = new Vector2(300, 100),
          Colour = Color.White,
          Speed = 3,
          
        },
      };



        }

        protected override void Update(GameTime gameTime)
        {
            
        foreach (var sprite in _sprites)
            sprite.Update(gameTime, _sprites);

        base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
            
        foreach (var sprite in _sprites)
          
                sprite.Draw(_spriteBatch);
             
            
            
            _spriteBatch.End();

        base.Draw(gameTime);
        }
    }
}