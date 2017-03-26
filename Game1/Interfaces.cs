using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    interface IDrawableObject
    {
        bool Visible { get; set; }
        Texture2D GetTexture();
        void LoadTexture(Texture2D texture);
        Rectangle GetRect();
        Color GetColor();

    }

    interface IUpdatableObject
    {
        Vector2 GetVelocity();
        Rectangle GetRect();
        bool Collidable { get; set; }

        void ChangePosition(Vector2 pos);
        Vector2 GetPos();
        void InvertXVel();
        void InvertYVel();
        void ChangeVelocity(Vector2 vel);
        void ChangeVelocity(float x,float y);

        void ChangeAngle(float angle);

    }



}
