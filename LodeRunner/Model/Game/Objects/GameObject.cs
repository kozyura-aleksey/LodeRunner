using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Абстрактный класс - объект игры
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// Координата x
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Координата y
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public GameObject(float parX, float parY)
        {
            X = parX;
            Y = parY;
        }

        /// <summary>
        /// Метод создания объекта
        /// </summary>
        /// <param name="parType"></param>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        /// <returns></returns>
        public static GameObject CreateObject(String parType, float parX, float parY)
        {
            GameObject object1 = null;
            switch (parType)
            {
                case "1":
                    object1 = new Brick(parX, parY);
                    break;

                case "2":
                    object1 = new Concrete(parX, parY);
                    break;

                case "3":
                    object1 = new Stairs(parX, parY);
                    break;

                case "4":
                    object1 = new Rope(parX, parY);
                    break;

                case "5":
                    object1 = new Enemy(parX, parY);
                    break;

                case "6":
                    object1 = new Gold(parX, parY);
                    break;

                case "7":
                    object1 = new Man(parX, parY);
                    break;
            }
            return object1;
        }

        /// <summary>
        /// Движение объекта игры вправо
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public float moveRightObject()
        {
            X += 16;
            return X;
        }

        /// <summary>
        /// Движение объекта игры вверх
        /// </summary>
        /// <param name="parY"></param>
        public float moveUpObject()
        {
            Y -= 16;
            return Y;
        }

        /// <summary>
        /// Движение объекта игры влево
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public float moveLeftObject()
        {
            X -= 16;
            return Y;
        }

        /// <summary>
        /// Движение объекта игры вниз
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public float moveDownObject()
        {
            Y += 16;
            return Y;
        }


        /// <summary>
        /// Получение информации об объекте
        /// </summary>
        /// <returns>Информация об объекте</returns>
        public virtual string Info()
        {
            StringBuilder info = new StringBuilder();

            info.AppendLine(string.Format("Координата x: {0}", X));
            info.AppendLine(string.Format("Координата y: {0}", Y));

            return info.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        public abstract String NameObject();


        public override string ToString()
        {
            return "X: " + X + "  Y: " + Y;
        }

    }
}

