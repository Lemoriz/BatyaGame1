using System;

using Microsoft.Xna.Framework;

namespace Game1
{
    abstract class GameObject : IUpdatableObject
    {

        protected Vector2 _pos;
        protected Rectangle Rect;
        protected Vector2 Velocity;
        private float _rotation;
        private float _rotationSpeed;
        public bool Collidable { get; set; }

        /// <summary>
        /// Game object constructor
        /// </summary>
        /// <param name="vel">Velocity</param>
        /// <param name="rect">Rectangle</param>
        /// <param name="rotSpeed">rotation speed</param>
        /// <param name="Collidable">Is collidable?</param>
        protected GameObject(Vector2 vel, Rectangle rect, float rotSpeed, bool Collidable)
        {
            this.Collidable = Collidable;
            this.Rect = rect;
            Velocity = vel;
            _rotation = 0;
            _rotationSpeed = rotSpeed;
        }

        public void ChangePosition(Vector2 pos)
        {
            this._pos = pos;
            Rect.Location = _pos.ToPoint();
        }

        public Vector2 GetPos()
        {
            return _pos;
        }

        public void InvertXVel()
        {
            Velocity.X *= -1;
        }

        public void InvertYVel()
        {
            Velocity.Y *= -1;
        }

        public void ChangeVelocity(Vector2 vel)
        {
            Velocity = vel;
        }

        public void ChangeVelocity(float x, float y)
        {
            Velocity.X = x;
            Velocity.Y = y;
        }
   
        public Rectangle GetRect()
        {
            return Rect;
        }

        public void ChangeAngle(float f)
        {
            
        }

        protected GameObject()
        {

        }

        /// <summary>
        /// Count the next position
        /// </summary>
        /// <param name="f"></param>

        public Vector2 GetVelocity()
        {
            return Velocity;
        }


    }
}
