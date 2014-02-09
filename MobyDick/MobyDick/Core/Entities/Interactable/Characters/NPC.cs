namespace MobyDick.Entities.Interactable.Characters
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    internal class NPC : Character
    {
        public NPC(Texture2D texture, Rectangle form, int health, int velocity, Vector2 position, Color color, SpriteBatch spriteBatch)
            : base(texture, form, health, velocity, position, color, spriteBatch)
        {

        }
    }
}
