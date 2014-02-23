namespace MobyDick
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using MobyDick.Core.Entities;
    using MobyDick.Core.Entities.Interactable.Characters;
    using MobyDick.Core.Entities.Interactable.Items;
    using MobyDick.Core.Screen;
    using System;
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MobyDickGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Scene scene;
        World world;
        public MobyDickGame()
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
            BaseEntity<IEntity>.SetGameContext(this);
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
            Texture2D whaleKiller = Content.Load<Texture2D>("whale_killer");
            Texture2D zombieLink = Content.Load<Texture2D>("zombie_link");
            Texture2D ggg = Content.Load<Texture2D>("good_guy_greg");
            Texture2D dogNpc = Content.Load<Texture2D>("dog_npc");
            Texture2D blueNpc = Content.Load<Texture2D>("blue_npc");
            Texture2D creepyJane = Content.Load<Texture2D>("creepy_jane");
            Texture2D sceneTexture = Content.Load<Texture2D>("Telepath2");
            Texture2D stt = Content.Load<Texture2D>("stt");
            world = World.MakeWorld(Content, spriteBatch);
            world.AddTexture("batman", "batman_sprite");
            world.CreatePlayer("batman", new Rectangle(0, 0, 30, 33), new Vector2(0, 0), Color.White);

            scene = new Scene(sceneTexture, new Rectangle(0, 0, 714, 512), new Vector2(0, 0), Color.Wheat, "scene 1");
            var wk = new Enemy(whaleKiller, new Rectangle(0, 0, 40, 50), 100, 2,
                new Vector2(50, 50), Color.White, spriteBatch);
            var zl = new Enemy(zombieLink, new Rectangle(0, 0, 30, 36), 100, 1,
                new Vector2(60, 0), Color.White, spriteBatch);
            var dog = new NPC(dogNpc, new Rectangle(0, 0, 30, 36), 100, 5,
                new Vector2(60, 0), Color.White, spriteBatch);
            var sttt = new BaseItem(stt, new Rectangle(0, 0, stt.Width, stt.Height), new Vector2(150, 150), Color.White, ItemType.Weapon);
            Texture2D proj = Content.Load<Texture2D>("list-style-type-active");
            var projectile = new BaseItem(proj, new Rectangle(0, 0, 16, 16), new Vector2(200, 200), Color.White, ItemType.Weapon);
            scene.AddNPC(wk);
            scene.AddItem(sttt);
            scene.AddNPC(zl);
            scene.AddItem(projectile);
            //scene.AddNPC(dog);
            world.AddScene(scene);
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
            //character.Update(gameTime);
            world.Update(gameTime);
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
            world.Draw();
            //character.Draw();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
