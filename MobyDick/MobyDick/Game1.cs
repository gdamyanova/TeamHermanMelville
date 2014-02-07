using System;
using System.Collections.Generic;
using System.Linq;
using MobyDick.Entities;
using MobyDick.Entities.Interactable;
using MobyDick.Entities.Interactable.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MobyDick
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player character;
        Scene scene;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D batman = Content.Load<Texture2D>("batman_sprite");
            Texture2D whaleKiller = Content.Load<Texture2D>("whale_killer");
            Texture2D zombieLink = Content.Load<Texture2D>("zombie_link");
            Texture2D ggg = Content.Load<Texture2D>("good_guy_greg");
            Texture2D dogNpc = Content.Load<Texture2D>("dog_npc");
            Texture2D blueNpc = Content.Load<Texture2D>("blue_npc");
            Texture2D creepyJane = Content.Load<Texture2D>("creepy_jane");

            character = new Player(batman, new Rectangle(0, 0, 30, 33), 100, 5,
                new Vector2(0, 0), Color.White, spriteBatch);

            Texture2D sceneTexture = Content.Load<Texture2D>("Telepath2");
            scene = new Scene(sceneTexture, new Rectangle(0, 0, 714, 512), new Vector2(0, 0), Color.Wheat, "scene 1");

            var wk = new NPC(whaleKiller, new Rectangle(0, 0, 40, 50), 100, 5,
                new Vector2(50, 50), Color.White, spriteBatch);
            var zl = new NPC(zombieLink, new Rectangle(0, 0, 30, 36), 100, 5,
                new Vector2(60, 0), Color.White, spriteBatch);
            var dog = new NPC(dogNpc, new Rectangle(0, 0, 30, 36), 100, 5,
                new Vector2(60, 0), Color.White, spriteBatch);
            scene.AddNPC(wk);
            scene.AddNPC(zl);
            scene.AddNPC(dog);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            character.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            scene.Draw(spriteBatch);
            character.Draw();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
