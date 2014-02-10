namespace MobyDick
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Entities;
    using MobyDick.Entities.Interactable.Characters;
    using System.Collections.Generic;
    class World
    {
        #region Events
        delegate bool EventHandler(bool item);
        event EventHandler Collision;
        #endregion
        #region Properties
        private Dictionary<string, Scene> Scenes;
        private Scene CurrentScene { get; set; }
        private Player PlayerEntity;
        private ContentManager Content { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private static World instance;

        private Dictionary<string, Texture2D> Textures;
        #endregion
        #region Constructors
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
        #endregion
        #region Methods
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

        private bool DetectCollisions(object sender)
        {
            var entity = sender as Character;
            Rectangle newEntityBoundingBox = new Rectangle();
            switch (entity.currentDirection)
            {
                case MobyDick.Entities.Interactable.Directions.Down:
                    newEntityBoundingBox = new Rectangle((int)entity.Position.X, (int)entity.Position.Y + entity.Velocity, entity.Form.Width, entity.Form.Height);
                    break;
                case MobyDick.Entities.Interactable.Directions.Left:
                    newEntityBoundingBox = new Rectangle((int)entity.Position.X - entity.Velocity, (int)entity.Position.Y, entity.Form.Width, entity.Form.Height);
                    break;
                case MobyDick.Entities.Interactable.Directions.Right:
                    newEntityBoundingBox = new Rectangle((int)entity.Position.X + entity.Velocity, (int)entity.Position.Y, entity.Form.Width, entity.Form.Height);
                    break;
                case MobyDick.Entities.Interactable.Directions.Up:
                    newEntityBoundingBox = new Rectangle((int)entity.Position.X, (int)entity.Position.Y - entity.Velocity, entity.Form.Width, entity.Form.Height);
                    break;
                default:
                    break;
            }
            foreach (var item in this.CurrentScene.Obsticles)
            {
                if (newEntityBoundingBox.Intersects(item.BoundingBox))
                {
                    if (this.Collision != null)
                    {
                        this.Collision.Invoke(false);
                    }
                    return true;
                }
            }
            foreach (var item in this.CurrentScene.NPCS)
            {
                if (newEntityBoundingBox.Intersects(item.BoundingBox))
                {
                    if (this.Collision != null)
                    {
                        this.Collision.Invoke(false);
                    }
                    return true;
                }
            }
            if (this.Collision != null)
            {
                this.Collision.Invoke(true);
            }
            return true;
        }

        public void CreatePlayer(string playerTexture, Rectangle form, Vector2 position, Color color)
        {
            this.PlayerEntity = new Player(this.Textures[playerTexture], form, 100, 5, position, color, this.spriteBatch);
            this.Collision += this.PlayerEntity.HandleMoveCollision;
            this.PlayerEntity.MoveEvent += this.DetectCollisions;
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
        #endregion
    }
}
