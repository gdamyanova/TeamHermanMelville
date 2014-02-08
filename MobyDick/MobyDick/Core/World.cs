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
    class World
    {
        private Dictionary<string, Scene> Scenes;
        private Scene CurrentScene { get; set; }
        private Player PlayerEntity;
        private ContentManager Content { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private static World instance;

        private Dictionary<string, Texture2D> Textures;
        private World(ContentManager content, SpriteBatch spriteBatch)
        {
            this.Scenes = new Dictionary<string, Scene>();
            this.Textures = new Dictionary<string, Texture2D>();
            this.Content = content;
            this.spriteBatch = spriteBatch;
        }
        public static World MakeWorld(ContentManager content, SpriteBatch spriteBatch)
        {
            if (instance == null)
            {
                instance = new World(content, spriteBatch);
            }
            return instance;
        }

        public void AddScene(Scene scene)
        {
            this.Scenes.Add(scene.SceneName, scene);
            if (this.CurrentScene == null)
            {
                this.CurrentScene = scene;
            }
        }

        public void AddScene(string textureName)
        {
            string sceneName = textureName;
            Scene scene = new Scene(this.Textures[textureName], new Rectangle(0, 0, this.Textures[textureName].Width, this.Textures[textureName].Height), new Vector2(0, 0), Color.White, sceneName);
            this.AddScene(scene);
        }

        public void AddScene(string textureName, string sceneName)
        {
            Scene scene = new Scene(this.Textures[textureName], new Rectangle(0, 0, this.Textures[textureName].Width, this.Textures[textureName].Height), new Vector2(0, 0), Color.White, sceneName);
            this.AddScene(scene);
        }

        private void ChangeScene(string sceneName)
        {
            if (this.Scenes.ContainsKey(sceneName))
            {
                this.CurrentScene = this.Scenes[sceneName];
            }
        }

        public void CreatePlayer(string playerTexture, Rectangle form, Vector2 position, Color color)
        {
            this.PlayerEntity = new Player(this.Textures[playerTexture], form, 100, 10, position, color, this.spriteBatch);
        }

        public void AddTexture(string textureName, string assetName)
        {
            this.Textures.Add(textureName, this.Content.Load<Texture2D>(assetName));
        }

        public void Draw()
        {
            this.CurrentScene.Draw(this.spriteBatch);
            this.PlayerEntity.Draw();
        }

        public void Update(GameTime gameTime)
        {
            this.CurrentScene.Update(gameTime);
            this.PlayerEntity.Update(gameTime);
        }
    }
}
