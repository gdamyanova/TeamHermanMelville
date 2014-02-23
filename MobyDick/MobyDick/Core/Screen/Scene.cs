namespace MobyDick.Core.Screen
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using MobyDick.Core.Entities;
    using MobyDick.Core.Entities.Interactable.Characters;
    using MobyDick.Core.Entities.Interactable.Items;
    using System.Collections.Generic;
    class Scene : BaseEntity<Scene>, IEntity
    {
        #region Properties
        private Dictionary<string, Scene> LinkedScenes;
        public List<BaseItem> Obstacles;
        public List<BaseItem> Items;
        public List<NPC> NPCS;
        public List<AnimatedEntity> AnimatedEntities;
        public string SceneName { get; private set; }
        #endregion
                                                                                      
        #region Constructors
        public Scene(Texture2D texture, Rectangle form, Vector2 position, Color color, string sceneName)
            : base(texture, form, position, color)
        {
            this.SceneName = sceneName;
            this.NPCS = new List<NPC>();
            this.Obstacles = new List<BaseItem>();
            this.LinkedScenes = new Dictionary<string, Scene>();
            this.Items = new List<BaseItem>();
            this.AnimatedEntities = new List<AnimatedEntity>();
        }
        #endregion

        #region Methods
        public void LinkScene(string sceneName, Scene scene)
        {
            this.LinkedScenes.Add(sceneName, scene);
        }

        public Scene GetScene(string sceneName)
        {
            if (this.LinkedScenes.ContainsKey(sceneName))
            {
                return this.LinkedScenes[sceneName];
            }
            else
            {
                return null;
            }
        }

        public void AddObsticle(BaseItem obsticle)
        {
            this.Obstacles.Add(obsticle);
        }

        public void AddItem(BaseItem item)
        {
            this.Items.Add(item);
        }

        public void RemoveItemFromScene(BaseItem item)
        {
            this.Items.Remove(item);
        }

        public void AddNPC(NPC npc)
        {
            this.NPCS.Add(npc);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update();
            foreach (var obsticle in this.Obstacles)
            {
                obsticle.Update();
            }
            foreach (var npc in this.NPCS)
            {
                npc.Update();
            }
            foreach (var item in this.Items)
            {
                item.Update();
            }
            foreach (var item in this.AnimatedEntities)
            {
                item.Update();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var obsticle in this.Obstacles)
            {
                obsticle.Draw(spriteBatch);
            }
            foreach (var npc in this.NPCS)
            {
                npc.Draw();
            }
            foreach (var item in this.Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (var item in this.AnimatedEntities)
            {
                item.Draw();
            }
        }

        public void AddMovingEntity(AnimatedEntity entity)
        {
            this.AnimatedEntities.Add(entity);
        }
        #endregion
    }
}
